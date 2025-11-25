using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimits : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("ProjEnemy")) //Can use else if for other objects??
        {
            Destroy(collision.transform.parent.transform.parent.gameObject); //This gets rid of the thrown enemy.
                             //So this has to get rid of the "grandparent" of the object since this is reading the hitbox, 2 gens down from the thrown enemy itself.
        }
    }
}
