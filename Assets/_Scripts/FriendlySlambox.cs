using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlySlambox : MonoBehaviour
{
    //This script turns enemies into KO'd enemies. This goes onto explosions from the acro throws.
    public GameObject[] whatHit; //Array of prefabs for ***KO'd*** enemies, for now I plan to have defeat animations baked into the prefab
    public float bumpForce = 3.00f; //Set in editor, slam knockback
    public float damage = 3.00f; //Set in editor, slam damage
    

    private void OnTriggerEnter(Collider collision)
    {
       

        if (collision.transform.CompareTag("EnemyS")) //Can use else if for other enemy types/stack tiers
        {
            GameManager.Score += 10; //PlaceHolder value, can use EXP instead/also spawn exp drops for stuff like this

            Instantiate(whatHit[0], transform.position, Quaternion.Euler(48f, 0f, 0f)); //Can have hardcoded numbers instead of variables for the prefab Arr., thanks to else if structure
            Destroy(collision.transform.parent.gameObject); //Also get rid of the enemy that was hit
                                                            //This is set to destroy the parent because the hitbox is a separate object
        }

        else if (collision.transform.CompareTag("Enemy")) //Can use else if for other enemy types/stack tiers
        {
            GameManager.Score += 20; //PlaceHolder value, can use EXP instead/also spawn exp drops for stuff like this

            Instantiate(whatHit[1], transform.position, Quaternion.Euler(48f, 0f, 0f)); //Can have hardcoded numbers instead of variables for the prefab Arr., thanks to else if structure
            Destroy(collision.transform.parent.gameObject); //Also get rid of the enemy that was hit
                                                            //This is set to destroy the parent because the hitbox is a separate object
        }

        else if (collision.transform.CompareTag("EnemyT")) //Can use else if for other enemy types/stack tiers
        {
            
            EnemyManagertest hitEnemy = collision.gameObject.GetComponentInParent<EnemyManagertest>();
            if (hitEnemy != null && !hitEnemy.antiDumper)
            {
                hitEnemy.antiDumper = true;

                if (!hitEnemy.kbApplied) //If the enemy wasn't JUST hit
                {
                    if (hitEnemy.atLethal) //If the enemy is at Lethal/ can be KO'd by the next hit
                    {
                        GameManager.Score += 50; //PlaceHolder value, can use EXP instead/also spawn exp drops for stuff like this
                        Instantiate(whatHit[2], transform.position, Quaternion.Euler(61.6f, 0f, 0f)); //Can have hardcoded numbers instead of variables for the prefab Arr., thanks to else if structure
                        Destroy(collision.transform.parent.gameObject); //Also get rid of the enemy that was hit
                                                                        //This is set to destroy the parent because the hitbox is a separate object
                       
                    }

                    else //Take damage and KB
                    {

                        if (hitEnemy != null)
                        {
                            Rigidbody rb = hitEnemy.rb;
                            hitEnemy.TakeDamage(damage);
                            Vector3 myCenter = transform.position;
                            Vector3 closestPoint = collision.ClosestPoint(myCenter);
                            myCenter.y = closestPoint.y;
                            Vector3 forceVector = Vector3.zero;  //Set forceVector to the opposite direction the enemy is moving                         
                            forceVector.x = (hitEnemy.rb.velocity.x / hitEnemy.speed) * -1;
                            forceVector.z = (hitEnemy.rb.velocity.z / hitEnemy.speed) * -1;
                            forceVector = forceVector.normalized;
                            Debug.LogWarning($"Force Vector is to [{forceVector.x}, {forceVector.y}, {forceVector.z}] !");
                            if (forceVector.magnitude < 0.05f)
                            {
                                forceVector.x = (Random.value);
                                forceVector.z = (Random.value);
                                forceVector = forceVector.normalized;
                                Debug.LogWarning($"Force Vector randomized to [{forceVector.x}, {forceVector.y}, {forceVector.z}] !");
                            }


                            hitEnemy.kbApplied = true;

                            rb.AddForce(forceVector * bumpForce, ForceMode.Impulse);

                        }

                    }
                }


            }


        }
    }

    
}
