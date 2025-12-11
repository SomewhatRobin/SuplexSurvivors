using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    [Header("Chip Settings")]
    public bool isHost = false;                // Host or Guest chip
    public GameObject nextTierPrefab;          // Assign in Inspector per enemy type
    public float guestDuration = 1.2f;         // Time a guest stays active before restoring

    private float hostValue;                   // Random value for host competition
    private HashSet<Chip> currentGuests = new HashSet<Chip>();

    private GameObject enemyRoot;              // Top-level enemy object
    private Chip guestChip;                    // Reference to our guest chip
    private bool isGuestActive = false;
    private float guestTimer = 0f;
    private float guestValue = -3.0f;
    //private int combGuests, comb1Guests, comb2Guests = 0; //Guest combination count

    private bool hasCombined = false;          // Prevent double-combine

    void Awake()
    {
        enemyRoot = transform.root.gameObject;
    }

    void Start()
    {
        if (isHost)
        {
            hostValue = Random.value;

            // Safe lookup for GuestChip
            Transform guestTransform = transform.parent.Find("GuestChip");
            if (guestTransform != null)
            {
                guestChip = guestTransform.GetComponent<Chip>();
                guestChip.isHost = false;
                guestChip.isGuestActive = false;
                guestChip.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning($"{enemyRoot.name} has no GuestChip assigned!");
            }
        }
    }

    void Update()
    {
        if (isGuestActive)
        {
            guestTimer += Time.deltaTime;
            if (guestTimer >= guestDuration)
                RestoreHost();

        }
    }

    // =======================
    // TRIGGER LOGIC
    // =======================
    private void OnTriggerEnter(Collider other)
    {
        Chip otherChip = other.GetComponent<Chip>();
        if (otherChip == null) return;

        // Host vs Host conflict
        if (isHost && otherChip.isHost)
        {
            CompareHosts(otherChip);
        }

        // Host receiving guests
        if (isHost && otherChip.isGuestActive)
        {
            currentGuests.Add(otherChip);
            CheckForCombine();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Chip otherChip = other.GetComponent<Chip>();
        if (otherChip == null) return;

        // Remove leaving guests
        if (isHost && currentGuests.Contains(otherChip))
        {
            currentGuests.Remove(otherChip);
        }

        // If guest leaves a host area, start timer
        if (!isHost && isGuestActive)
        {
            guestTimer = 0f;
        }
    }

    // =======================
    // HOST COMPARISON
    // =======================
    private void CompareHosts(Chip other)
    {
        if (hostValue < other.hostValue)
         BecomeGuest(other.hostValue);
    }

    // =======================
    // GUEST LOGIC
    // =======================
    private void BecomeGuest(float gV)
    {
        if (guestChip == null) return;

        // Immediately mark as guest
        isHost = false;
        isGuestActive = true;
        

        guestTimer = 0f;
        guestValue = gV;

        // Swap GameObjects
        this.gameObject.SetActive(false);
        guestChip.gameObject.SetActive(true);
        if (enemyRoot == null)
        {
             enemyRoot = transform.root.gameObject;
        }
       

        // Ensure guest chip is properly active
        guestChip.isHost = false;
        guestChip.isGuestActive = true;
        guestChip.guestTimer = 0f;

        Debug.Log($"{enemyRoot.name} became GUEST");
    }

    private void RestoreHost()
    {
        isHost = true;
        isGuestActive = false;

        this.gameObject.SetActive(true);

        if (guestChip != null)
        {
            guestChip.isGuestActive = false;
            guestChip.gameObject.SetActive(false);
        }

        Debug.Log($"{enemyRoot.name} restored to HOST");
    }

    // =======================
    // COMBINE LOGIC
    // =======================
    private void CheckForCombine()
    {
        if (isHost && currentGuests.Count >= 3 && !hasCombined)
        {
            CombineSignal();
            DoCombine();
        }
    }

    private void CombineSignal()
    {
        //Handles up to 3 simultaneous combinations, cycles combination values when one has been used.
        if (GameManager.combineValue < 0.00001f)
        {
            GameManager.combineValue = hostValue;
        }
        else if (GameManager.combineValue > 0.00001f && GameManager.combineValue1 < 0.00001f)
        {
            GameManager.combineValue1 = hostValue;
            GameManager.combineValue = 0f;
        }
        else if (GameManager.combineValue1 > 0.00001f && GameManager.combineValue2 < 0.00001f)
        {
            GameManager.combineValue2 = hostValue;
            GameManager.combineValue1 = 0f;
        }
        else
        {
            GameManager.combineValue = hostValue;
            GameManager.combineValue2 = 0f;
        }

    }

    private void DoCombine()
    {
        hasCombined = true;
        Debug.Log($"{enemyRoot.name} COMBINED into next tier!");

        if (nextTierPrefab != null)
        {
            Instantiate(nextTierPrefab, enemyRoot.transform.position, enemyRoot.transform.rotation);
        }

        Destroy(enemyRoot);
    }
}