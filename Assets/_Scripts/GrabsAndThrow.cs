using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabsAndThrow : MonoBehaviour
{
    //0,1 are Player's hands, visible. 2 is held enemy above the player's head, invisible/inactive at start
    public GameObject[] myHands;
    //Player's grab target, invis(?)
    public Transform[] waypoint;
    public GameObject armCast; //Set up for below
   
    //Arm-merang goes to and from the player
    private Vector3 currentTarget; //From Ass4, platform movement for the grab
    public bool armStretch; //Are the arms going to(true) or from(false) the player?
    public float tolerance = 0.05f; //From Ass4, tolerance for not quite reaching the target
   
    //What the player has grabbed, whether the player has grabbed
    public int theHaul; //For communicating with Throw script, checks for whether an Enemy has been grabbed
    public bool inHand; //Split second variable so the arms can return, can tell that an enemy is in hand(s)
    public bool lifted; //As above, for dash grab
    public GameObject[] heldEnemy; //The enemy the player has grabbed, being held.
    public Sprite[] theHeld; //Graphic for held enemy

    //logic stuff for delays and input reading
    public bool counterHit;
    private bool inTheLoop;
    public bool endLag;
    public bool btnPress;

    //Variables for launch grab
    public float launchForce = 3f; //Change this in editor, is now
    public float launchMult;
   
    public bool grabby, dash; //Is the grab in progress? Is the dash in use?
    public bool goFar, goNear, doneGrab; //For the grab going where it should

    public float secondsHeld = 0f; //Public so it's visible in editor
    public float targetTimeHeld = 0.75f; //Public to be editable in editor
    public float coolDown = 0.4f; // "Visible" delay, shorter than actual delay. Public so this can be changed in editor.

  


    public Color handShade; 

    public KeyCode kbGrab; //These 3 are changable in Editor
    public KeyCode crGrab;
    public KeyCode crGrab2;

    //public int heldShade = 0;
    // Start is called before the first frame update
    void Start()
    {
        secondsHeld = 0f;
        handShade = new Color(0.7f, 0.2f, 0.7f, 1f); 
        counterHit = false;
        endLag = false;
        btnPress = false;

        dash = false;
        grabby = false;
        launchMult = 1f;
        armStretch = true;
        theHaul = 0;
        inHand = false;
        lifted = false;
        myHands[2].SetActive(false);
        goFar = true;
        goNear = false;
        //wizRobe = armCast.GetComponentInParent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (counterHit) //If player is in endlag
        {

            if (secondsHeld > 4.0f * targetTimeHeld && !grabby)
            {
                //This is to fix some weird bug where the arms can get stuck. For now this goes nuclear and sets everything to a default-ish state
                Debug.LogWarning("You wave your hands and wiggle your fingers...");
                counterHit = false;
                goFar = true;
                doneGrab = false;
                armStretch = true;
                btnPress = false;
                grabby = false;
                inHand = false;
                endLag = false;
                theHaul = 0;
                myHands[2].SetActive(false);
                secondsHeld = 0f;

            }


            Invoke("reCastHands", 0.2f);

            if (!endLag) //ready cannot begin without reCastHands giving the go-ahead
            {
                Invoke("readyHands", 0.2f + coolDown);
            }

        }

        else if (!counterHit && !inHand) //If player is not in endlag, has empty hands
        {

            //Controls are Space, A, or B on controller for grab
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(crGrab) || Input.GetKeyDown(crGrab2))
            {
                btnPress = true;
                secondsHeld = 0f;
                myHands[0].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, handShade, secondsHeld / (targetTimeHeld * 1.25f));
                myHands[1].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, handShade, secondsHeld / (targetTimeHeld * 1.25f));
            }


            if (Input.GetKey(KeyCode.Space) || Input.GetKey(crGrab) || Input.GetKey(crGrab2))
            {
                secondsHeld += Time.deltaTime;
                //Hands can shake here as part of an animation
                
                if (secondsHeld < targetTimeHeld * 1.25f)
                {
                    myHands[0].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, handShade, secondsHeld / (targetTimeHeld * 1.25f));
                    myHands[1].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, handShade, secondsHeld / (targetTimeHeld * 1.25f));
                }
                else
                {
                    myHands[0].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, handShade, 1f);
                    myHands[1].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, handShade, 1f);
                }

                if (secondsHeld > targetTimeHeld * 0.75f && !goFar)
                {
                    goFar = true;
                    doneGrab = false;
                }

            }

            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(crGrab) || Input.GetKeyUp(crGrab2))
            {

                btnPress = false; //Not pressing a button when you stop pressing a button

                float timePct = secondsHeld / targetTimeHeld;
                if (timePct >= 1.0f)
                {
                    timePct = 1.0f;

                    myHands[0].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, 1f);
                    myHands[1].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, 1f);


                    launchMult = 1f;
                    goFar = true;
                    //mageGrip();
                    grabby = true;
                    counterHit = true;
                    endLag = true;
                }

                else
                {
                    timePct = 0f;

                    myHands[0].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.blue, 1f);
                    myHands[1].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.blue, 1f);
                    if (GameManager.staMana > 0 && (!counterHit || !endLag))
                    {
                        GameManager.staMana++;
                        //Player dash grab goes here
                        Debug.LogWarning("Dash Grab!");
                        dash = true;
                        counterHit = true;
                        endLag = true;

                    }
                    
                    
                   
                }

            }
        }

        if (grabby)
        {
            mageGrip();
        }

        if (inHand) //If the player has an enemy in Hand, regardless of endLag/counterHit
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(crGrab) || Input.GetKeyDown(crGrab2))
            {
                btnPress = true;
               
            }


            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(crGrab) || Input.GetKeyUp(crGrab2))
            {
                myHands[2].SetActive(false);
                Instantiate(heldEnemy[theHaul - 1], transform.position, Quaternion.Euler(-45f, 0f, 0f));
                btnPress = false;
                theHaul = 0;
                inHand = false;
            }

        }

    }

    private void mageGrip() //Launch grab
    {
        if(theHaul != 0)
        {
            myHands[2].SetActive(true);
            //Resets variables to mirror state after whiff
            goFar = false;
            goNear = false;
            armStretch = true;
            doneGrab = true;
            transform.position = waypoint[1].position; //Teleports(?) arms to player
            //Add something here to skip cooldowns, this should let you throw RIGHT away
            inHand = true;
            SpriteRenderer sr = myHands[2].GetComponent<SpriteRenderer>();
            sr.sprite = theHeld[theHaul-1];

        }

        if(inHand)
        {
            return;
        }
        
        if (endLag)
        {
            Debug.Log("Launch Grab!");

        }

        if (armStretch && goFar)
        {
            //Has hands go towards the target, slowing down as it gets further from the player
            transform.position = Vector3.MoveTowards(transform.position, waypoint[0].position, launchForce *
                (Vector3.Distance(transform.position, waypoint[0].position)) + (launchForce/3f));
            //This has the base speed get multiplied by the distance, and has a third of the base speed added to the final result
            //Ensuring the arms are moving at a bare minimum pace no matter how close they get to the target
        }

        else if (!armStretch && goNear)
        {
            //Has hands return from the target, speeding up as it gets closer to the player
                transform.position = Vector3.MoveTowards(transform.position, waypoint[1].position, launchForce * 
                    (Vector3.Distance(transform.position, waypoint[0].position)) + (launchForce / 3f));
            //This also has the same deal
            //Ensuring the arms are moving at a bare minimum pace no matter how far they are from the player
        }

        else
        {
            transform.localPosition = Vector3.zero;
        }

        //This is editable, so we can make this into an upgrade

        if (Vector3.Distance(waypoint[0].position, transform.position) < tolerance && armStretch)
        {
            SwitchTargets();
        }

        else if (Vector3.Distance(waypoint[1].position, transform.position) < tolerance && !armStretch)
        {
            SwitchTargets();
        }
       
    }

    private void bigbyBolt() //Grab part of dash grab
    {

        if (Vector3.Distance(waypoint[2].position, transform.position) < tolerance && !doneGrab)
        {
            doneGrab = true;
            Invoke("grabReset", 0.02f);
        }

        if (theHaul != 0)
        {
            myHands[2].SetActive(true);
            doneGrab = true;
            transform.position = waypoint[1].position; //Teleports(?) arms to player
            //Add something here to skip cooldowns, this should let you throw RIGHT away
            lifted = true;
            SpriteRenderer sr = myHands[2].GetComponent<SpriteRenderer>();
            sr.sprite = theHeld[theHaul - 1];
        }
    
    }

    public void grabReset()
    {
        doneGrab = false;
    }

    private void SwitchTargets()
    {
        if (armStretch)
        {
            armStretch = false;
            goFar = false;
            goNear = true;
        }
        else
        {
            armStretch = true;
            goNear = false;
            doneGrab = true;
        }
        
    }

    private void readyHands()
    {
        if (!grabby && !dash)
        {
            return;
        }

        if (counterHit)
        {
            Debug.LogWarning("Hands are ready.");
            myHands[0].GetComponent<Renderer>().material.color = Color.Lerp(Color.gray, Color.white, 1f);
            myHands[1].GetComponent<Renderer>().material.color = Color.Lerp(Color.gray, Color.white, 1f);
        }

        dash = false;
        grabby = false;
        counterHit = false;
        secondsHeld = 0f;
        
       
    }

    private void reCastHands()
    {
        if (endLag)
        {
            Debug.LogWarning("Hands are recasting...");
            secondsHeld = 0f;   
        }

        if (counterHit)
        {
            //secondsHeld += Time.deltaTime;
            myHands[0].GetComponent<Renderer>().material.color = Color.Lerp(Color.gray, Color.white, secondsHeld / (coolDown*1.5f));
            myHands[1].GetComponent<Renderer>().material.color = Color.Lerp(Color.gray, Color.white, secondsHeld / (coolDown*1.5f));
            
        }
        endLag = false; //Go ahead for running readyHands, doesn't reset timer float.

    }
}
