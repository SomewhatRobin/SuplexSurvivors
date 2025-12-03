using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float rollForce;
    public float speed;
    public float dashMult;
    public Transform dashGoal;
    public Vector3 myWay;
    public float vecMag = 0f;
    public float deadZone = 0.02f;
    public float targDist = 6f;
    public Vector3 armWay;
    public bool hiSpeed;
    public bool doneDash;
    public Vector3 dashDir;
    //public float dashDecay = 0.02f;

    // [SerializeField]
    //{ get; private set; }
    private Rigidbody rb;
    public SpriteRenderer theWiz;
    public GameObject hidArms;
    public GameObject armTango;
    public bool flipSprite;

    public GrabsAndThrow grabThrows;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myWay = new Vector3(0, 0, 0);
        armWay = new Vector3(0, 0, 0);
        dashGoal.position = armTango.transform.position;
        //theWiz = GetComponentInChildren<SpriteRenderer>();
        flipSprite = false;
        dashMult = 3f;
        hiSpeed = false;
        doneDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hiSpeed && rollForce - speed > 0.3f) //If the player is not dashing and the player's movespeed is way off the intended speed:
        {
            rollForce = speed;
        }
        
        if (!grabThrows.doneGrab && grabThrows.dash)
        {
            doneDash = false;
        }

        //Function for walking
        if (doneDash)
        {
            Stroll();
        }

        //Sprite flipping, moved this up here so it works. Only works if the player isn't holding the grab button and can use the grab button. Shorten to flippable state?
        if (myWay.x > deadZone && (!grabThrows.btnPress && !grabThrows.counterHit))
        {
            flipSprite = true;
            theWiz.flipX = true;
        }
        else if (myWay.x < deadZone && (!grabThrows.btnPress && !grabThrows.counterHit))
        {
            flipSprite = false;
            theWiz.flipX = false;
        }
        //Function for aiming
        SpinArms();
        //Dash Grab
        if (!doneDash)
        {
            turboLift();
        }
  
    }

    private void SpinArms()
    {
        //In the unity scene, the arms are attached to a parent object which has rotations set so this spins properly.

        //Sets arm rotation to go on xy instead of xz, preventing arms from spinning on the wrong axis
        //TODO: Fix this so arms don't snap to position, moving towards that position instead. Could do some time.deltaTime stuff with the armway calc?
        if (vecMag > deadZone && !grabThrows.btnPress && (!grabThrows.grabby) || grabThrows.inHand)
        {
            //Mumbo jumbo to get the Arms to face the direction the player is moving in.
            armWay.x = myWay.x;
            armWay.y = myWay.z;

            if (armWay != Vector3.zero)
            {
                hidArms.transform.localRotation = Quaternion.LookRotation(armWay, Vector3.forward);
            }
           

            //Piggybacking off mumjumbo to get arm target to rotate with arms, at a set (editable!) distance from the player
            if (armWay != Vector3.zero)
            {
                armTango.transform.localRotation = Quaternion.LookRotation(armWay, Vector3.back);
                armTango.transform.position = transform.position + (Vector3.Normalize(myWay) * targDist);
            }
            
        }
        else //Only changes aim direction if the player is moving, otherwise, arms should stay still
        {

            if (armWay != Vector3.zero)
            {
                hidArms.transform.localRotation = Quaternion.LookRotation(armWay, Vector3.forward);
            }

           // Don't update armTango here, the target does not move when the button is held.

            


        }
        
    }

    //Stroll now has movement that accounts for diagonals on Keyboard

    private void Stroll()
    {
        if (hiSpeed)
        {
            hiSpeed = false;
        }

        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");
        vecMag = Mathf.Sqrt((xDir * xDir) + (zDir * zDir)); //Calculates the Magnitude of the vector

        //None of this applies if the input falls in the deadZone.
        if (vecMag > deadZone)
        {
            if ((xDir * xDir) + (zDir * zDir) > 1.05f) //If the value of the input has it outside a circle w/ radius 1.05 [IF THEY ARE ON KB]
            {

                //Sets xDir and zDir to be (Direction / Magnitude), so total move speed is 1.
                //TODO: Shorten this, it doesn't need the if else anymore
                if (xDir > 0)
                {
                    /*
                    if (!theWiz.flipX)//&& !(grabThrows.endLag || grabThrows.btnPress))
                    {
                        flipSprite = true;
                    }
                    */
                    xDir = xDir / vecMag;
                   

                }
                else
                {
                    /*
                    if (theWiz.flipX)//&& !(grabThrows.endLag || grabThrows.btnPress))
                    {
                        flipSprite = false;
                    }
                    */
                    xDir = xDir / vecMag;
                   

                }

                if (zDir > 0)
                {
                    zDir = zDir / vecMag;
                }
                else
                {
                    zDir = zDir / vecMag;
                }
            }


            myWay.x = xDir;
            myWay.z = zDir;

           transform.position += myWay * speed * Time.deltaTime;
            
        }

         


    }

    private void turboLift() //Dash part of dash grab
    {
        if (!hiSpeed)
        {
            //Set the direction of the dash towards the target, Raise movement speed, and go REAL fast.
            //TODO: Start iFrames   
            dashDir = armTango.transform.position - transform.position;
            dashGoal.position = transform.position + (dashDir * 2);
            rollForce = speed * dashMult;
            rb.AddForce( rollForce * dashDir, ForceMode.Impulse);
            hiSpeed = true;
        }

        else if (hiSpeed)
        {
            //rb.velocity -= (rollForce * dashDecay) * dashDir;
            if ((transform.position - dashGoal.position).magnitude < 1f) //If the dash is over...
            {
             //End iFrames, turbo speed, and dash.   
                rb.velocity = Vector3.zero;

                doneDash = true;
            }
               
        }


    }
    //eof
}
