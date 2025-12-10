using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagertest : MonoBehaviour
{
    public float speed = 4.0f;  
    public float deltaSpeed = 3.0f;
    public float HP = 3.0f; //This will be set in the editor, dictates how much damage the enemy can take.
    public bool atLethal; //When an enemy runs out of health, they can be grabbed or defeated. For now, this only applies to BrickTon.
    public bool kbApplied; //For working with player hitboxes
    public bool antiDumper = false; //Flag to keep RD from duplicating BrickTon/other large enemies on kill.
    public GameObject nextTierPrefab;  // assign in inspector

    public Rigidbody rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        atLethal = false;
        antiDumper = false;
    }

    void Update()
    {
        if (player == null) return;

        if (antiDumper) //Delayed function to ensure RD doesn't multihit
        {
            Invoke("proDumper", 0.2f);
        }
        

        if (!kbApplied)
        {
            // Direction towards the player 
            Vector3 direction = (player.position - transform.position).normalized;

            // Create velocity towards the player 
            Vector3 vel = direction * speed;

            // Apply to the enemy 
            rb.velocity = vel;
        }

        else if (kbApplied)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            rb.velocity += direction * 10f * Time.deltaTime;
            Invoke("StopKB", 0.4f);
        }
    }

    private void StopKB()
    {
        kbApplied = false;
    }

    private void proDumper() //Resets RD flag so large enemies can still be hit by RD.
    {
        antiDumper = false;
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        Debug.Log($"Took {damage} points, HP is now {HP}");
        if (HP <= 0.0f) //Enemies with HP need to take enough damage to go to 0 HP, this makes them then work like other enemies
        {
            Debug.Log($"{transform.name} is at Lethal!");
            atLethal = true;
        }

    }


}