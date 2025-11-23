using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlungLaunch : MonoBehaviour
{
    private Transform flungAt; //Player's arm target
    private Rigidbody rb;
    public Vector3 launchDir; //Points towards player's arm target on enable

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();

        if (flungAt == null)
        {
            flungAt = GameObject.FindWithTag("PlayerAim").transform;
        }


         launchDir = flungAt.position - transform.position;
    }

    void Update()
    {
        rb.velocity = launchDir * 4f;
    }


}
