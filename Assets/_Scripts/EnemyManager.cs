using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float speed = 4.0f;  
    public float deltaSpeed = 3.0f; 
    private Rigidbody2D rb;
    private Transform player;
    public GameObject nextTierPrefab;  // assign in inspector

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        // Direction towards the player 
        Vector2 direction = (player.position - transform.position).normalized;

        // Create velocity towards the player 
        Vector2 vel = direction * speed;

        // Apply to the enemy 
        rb.velocity = vel;
    }
}