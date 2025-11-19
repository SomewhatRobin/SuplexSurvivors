using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabsAndThrow : MonoBehaviour
{
    //Player's hands, visible
    public GameObject[] myHands;
    //Player's grab target, invis(?)
    public Transform waypoint;
    public GameObject armCast; //Set up for below
    public Transform wizRobe; //Roughly the player's position
    private Vector3 currentTarget; //From Ass4, platform movement for the grab
    public bool armStretch; //Are the arms going to(true) or from(false) the player?
    public float tolerance = 0.05f; //From Ass4, tolerance for not quite reaching the target

    //logic stuff for delays and input reading
    public bool counterHit;
    private bool inTheLoop;
    public bool endLag;
    public bool btnPress;

    //Variables for launch grab
    public float launchForce = 3f;
    public float launchMult;
    private bool grabby;

    public float secondsHeld = 0f; //Public so it's visible in editor
    public float targetTimeHeld = 0.75f; //Public to be editable in editor
    public float coolDown = 0.4f; // "Visible" delay, shorter than actual delay. Public so this can be changed in editor.

  


    public Color handShade; //Purple

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
       
        grabby = false;
        launchMult = 1f;
        currentTarget = waypoint.localPosition;
        armStretch = true;
        wizRobe = armCast.GetComponentInParent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (counterHit) //If player is in endlag
        {
            
            Invoke("reCastHands", 0.2f);

            if (!endLag) //ready cannot begin without reCastHands giving the go-ahead
            {
                Invoke("readyHands", 0.2f + coolDown);
            }
            
        }

        else if (!counterHit) //If player is not in endlag
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
                // heldShade = (int)secondsHeld * 80;
                //handShade = (secondsHeld*80f , 0f, (2f * secondsHeld*80f) / 3f, 1f);
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

            }

            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(crGrab) || Input.GetKeyUp(crGrab2))
            {

                float timePct = secondsHeld / targetTimeHeld;
                if (timePct >= 1.0f)
                {
                    timePct = 1.0f;

                    myHands[0].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, 1f);
                    myHands[1].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, 1f);
                    //Hands lunge forwards for grab, another animation
                    //LaunchGrab()

                    launchMult = 1f;
                    mageGrip();
                    grabby = true;
                    counterHit = true;
                    endLag = true;
                }

                else
                {
                    timePct = 0f;

                    myHands[0].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.blue, 1f);
                    myHands[1].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.blue, 1f);
                    //Player dash grab goes here
                    Debug.Log("Dash Grab!");
                    counterHit = true;
                    endLag = true;
                }

            }
        }
        
        if (grabby)
        {
            mageGrip();
        }

    }

    private void mageGrip()
    {
        
        if (endLag)
        {
            Debug.Log("Launch Grab!");

        }

        if (armStretch)
        {
            transform.position = Vector3.MoveTowards(transform.localPosition, currentTarget, launchForce);
            //launchMult = 1.0f * (Vector3.Distance(transform.position, currentTarget));
        }

        else
        {
            if (Vector3.Distance(transform.position, Vector3.zero) < tolerance)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, wizRobe.localPosition, launchForce);
               // launchMult = 0.2f + (0.9f * (Vector3.Distance(transform.position, wizRobe.position)));
            }

            else
            {
                armStretch = true;
            }
        }

        //This is editable, so we can make this into an upgrade

        if (Vector3.Distance(currentTarget, transform.position) < tolerance)
        {
            SwitchTargets();
        }

       
    }

    private void SwitchTargets()
    {
        armStretch = false;
    }

    private void readyHands()
    {
        if (counterHit)
        {
            Debug.Log("Hands are ready.");
            myHands[0].GetComponent<Renderer>().material.color = Color.Lerp(Color.gray, Color.white, 1f);
            myHands[1].GetComponent<Renderer>().material.color = Color.Lerp(Color.gray, Color.white, 1f);
        }


        grabby = false;
        counterHit = false;
        secondsHeld = 0f;
        btnPress = false;
       
    }

    private void reCastHands()
    {
        if (endLag)
        {
            Debug.Log("Hands are recasting...");
            secondsHeld = 0f;   
        }

        if (counterHit)
        {
            secondsHeld += Time.deltaTime;
            myHands[0].GetComponent<Renderer>().material.color = Color.Lerp(Color.gray, Color.white, secondsHeld / (coolDown*1.5f));
            myHands[1].GetComponent<Renderer>().material.color = Color.Lerp(Color.gray, Color.white, secondsHeld / (coolDown*1.5f));
            
        }
        endLag = false; //Go ahead for running readyHands, doesn't reset timer float.

    }
}
