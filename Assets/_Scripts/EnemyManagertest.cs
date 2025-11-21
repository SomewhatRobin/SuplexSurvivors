using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagertest : MonoBehaviour
{
    public float speed = 4.0f;  
    public float deltaSpeed = 3.0f; 
    private Rigidbody rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        // Direction towards the player 
        Vector3 direction = (player.position - transform.position).normalized;

        // Create velocity towards the player 
        Vector3 vel = direction * speed;

        // Apply to the enemy 
        rb.velocity = vel;
    }
}