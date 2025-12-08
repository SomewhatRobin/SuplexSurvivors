using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    [Header("Config")]
    public bool isHostChip = true;   // true = Host, false = Guest
    public float guestRecoveryTime = 2f;

    [Header("Links")]
    public Chip hostChip;            // guest → host
    public Chip guestChip;           // host → guest

    [Header("Runtime Debug")]
    public float hostValue;          // random value
    public bool active = true;
    public bool combined = false;

    private float guestTimer;
    private HashSet<Chip> guestsInside = new HashSet<Chip>();

    void OnEnable()
    {
        if (isHostChip)
        {
            combined = false;
            active = true;
            hostValue = Random.value;            // Only hosts have value
            guestsInside.Clear();
        }
    }

    void Update()
    {
        if (!active) return;

        if (!isHostChip)
        {
            // Guest counting down to become host again
            guestTimer -= Time.deltaTime;
            if (guestTimer <= 0)
                BecomeHost();
        }
        else
        {
            // Host: check if 3 guests inside
            if (guestsInside.Count >= 3 && !combined)
            {
                combined = true;
                CombineValue(hostValue);
                Debug.Log($"{transform.parent.name} COMBINED into next tier!");
                Invoke("SelfDestruct", 0.75f);
            }
        }
    }

    private void SelfDestruct()
    {
        CombineValue(0.0f);
        Destroy(transform.parent.parent.parent.gameObject);
    }

    public static void CombineValue(float hV)
    {
        GameManager.combineValue = hV;
    }

    

    // Collision logic
    void OnTriggerEnter(Collider other)
    {
        Chip otherChip = other.GetComponent<Chip>();
        if (otherChip == null || !otherChip.active) return;

        // Host vs Host → compare and convert loser to guest
        if (isHostChip && otherChip.isHostChip)
            HandleHostCollision(otherChip);

        // Count guests inside
        if (isHostChip && !otherChip.isHostChip)
            guestsInside.Add(otherChip);
    }

    void OnTriggerExit(Collider other)
    {
        Chip otherChip = other.GetComponent<Chip>();
        if (otherChip == null) return;

        // Remove guest from inside count
        if (isHostChip)
            guestsInside.Remove(otherChip);

        // Guest leaving -> start timer to return to host
        if (!isHostChip)
            StartGuestTimer();
    }

    // Host vs Host comparison
    void HandleHostCollision(Chip other)
    {
        if (hostValue == other.hostValue)
            return; // rare tie

        if (hostValue < other.hostValue)
            BecomeGuest();
        // other will handle its own loss in its own script
    }

    // State changes
    void BecomeGuest()
    {
        Debug.Log($"{transform.parent.name} became GUEST");

        active = false;
        isHostChip = false;

        gameObject.SetActive(false);
        guestChip.gameObject.SetActive(true);

        guestChip.StartGuestTimer();
    }

    void StartGuestTimer()
    {
        guestTimer = guestRecoveryTime;
        active = true;
    }

    void BecomeHost()
    {
        Debug.Log($"{transform.parent.name} returned to HOST");

        active = true;
        isHostChip = true;

        gameObject.SetActive(false);
        hostChip.gameObject.SetActive(true);
    }
}