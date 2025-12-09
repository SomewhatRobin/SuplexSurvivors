using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowEmAll : MonoBehaviour
{
    public bool holdEm;
    public GrabsAndThrow gThoreau;


    // Start is called before the first frame update
    void Start()
    {
        holdEm = false;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (holdEm)
        {
            return;
        }

        if (gThoreau.grabby && !gThoreau.doneGrab) //If the (a?) grab is active...
        {
            if (collision.transform.CompareTag("EnemyS")) //Croc Snake
            {
                GameManager.Score += 5; //Another Placeholder, can use EXP instead, but this should be less than the score you get from hitting an enemy.
                gThoreau.theHaul = 1; //Making this an int instead of a bool so it can work with bigger enemies
                holdEm = true;
                Destroy(collision.transform.parent.gameObject);
            }

            else if (collision.transform.CompareTag("Enemy")) //Knight
            {
                GameManager.Score += 5; //Another Placeholder, can use EXP instead, but this should be less than the score you get from hitting an enemy.
                gThoreau.theHaul = 2; //Making this an int instead of a bool so it can work with bigger enemies
                holdEm = true;
                Destroy(collision.transform.parent.gameObject);
            }

            else if (collision.transform.CompareTag("EnemyT")) //BrickTon
            {
                /*
                 //TODO: Decide if this is a thing you can do
                if (collision.atLethal)
                {
                    GameManager.Score += 5; //No extra points for large foes grabbed
                    gThoreau.theHaul = 3; 
                    holdEm = true;
                    Destroy(collision.transform.parent.gameObject);
                }
                */
                //else cancel the grab, with nothing in hands

                    gThoreau.CleanGrab();

            }

        }

        else if (gThoreau.dash &&  !gThoreau.doneGrab) //If the dash grab is active...
        {
            //Something to make dash grab hitbox active goes here
            if (collision.transform.CompareTag("EnemyS"))
            {
                GameManager.Score += 5;
                gThoreau.theHaul = 1;
                gThoreau.lifted = true; //lifted set to true here, so it doesn't interact with mageGrip
                holdEm = true;
                Destroy(collision.transform.parent.gameObject);

            }

            else if (collision.transform.CompareTag("Enemy"))
            {
                GameManager.Score += 5; //Another Placeholder, can use EXP instead, but this should be less than the score you get from hitting an enemy.
                gThoreau.theHaul = 2; //Making this an int instead of a bool so it can work with bigger enemies
                gThoreau.lifted = true;
                holdEm = true;
                Destroy(collision.transform.parent.gameObject);
            }

            else if (collision.transform.CompareTag("EnemyT")) //BrickTon
            {
                //TODO: Decide if this is a thing you can do
                /*
                if (collision.atLethal)
                {
                    GameManager.Score += 5; //No extra points for large foes grabbed
                    gThoreau.theHaul = 3; 
                    gThoreau.lifted = true;
                    holdEm = true;
                    Destroy(collision.transform.parent.gameObject);
                }
                */

                //else do KB, no damage

            }


        }
    }



    // Update is called once per frame
    void Update()
    {
        if (!holdEm) 
        {
            return;
        }

        if (gThoreau.theHaul == 0)
        {
            holdEm = false;
        }
    }
}
