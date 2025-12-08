using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyHitbox : MonoBehaviour
{

    //This script turns enemies into KO'd enemies. This can go onto thrown enemies, explosions from the acro throws, etc.
    public GameObject[] whatHit; //Array of prefabs for ***KO'd*** enemies, for now I plan to have defeat animations baked into the prefab
    private int cuántosHit = 1; //How many enemies were hit by this hitbox, score scales up when another gets hit.


    private void OnTriggerEnter (Collider collision)
    {
        if (collision.transform.CompareTag("Enemy")) //Can use else if for other enemy types/stack tiers
        {
            GameManager.Score += 10 * cuántosHit; //PlaceHolder value, can use EXP instead/also spawn exp drops for stuff like this

            Instantiate(whatHit[0], transform.position, Quaternion.Euler(61.6f, 0f, 0f)); //Can have hardcoded numbers instead of variables for the prefab Arr., thanks to else if structure
            Destroy(collision.transform.parent.gameObject); //Also get rid of the enemy that was hit
                                                            //This is set to destroy the parent because the hitbox is a separate object

            cuántosHit++;
        }


    }

}
