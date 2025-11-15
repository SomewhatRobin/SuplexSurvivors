using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabsAndThrow : MonoBehaviour
{
    public GameObject[] myHands;
    public float secondsHeld = 0f;
    public float targetTimeHeld = 0.75f;
    public Color handShade;
    //public int heldShade = 0;
    // Start is called before the first frame update
    void Start()
    {
        secondsHeld = 0f;
        handShade = new Color(0.7f, 0.2f, 0.7f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            secondsHeld = 0f;
        }

       
        if (Input.GetKey(KeyCode.Space))
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

        if (Input.GetKeyUp(KeyCode.Space))
        {
            
            float timePct = secondsHeld / targetTimeHeld;
            if (timePct >= 1.0f)
            {
                timePct = 1.0f;
     
                myHands[0].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, 1f);
                myHands[1].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, 1f);
                //Hands lunge forwards for grab, another animation
                //LaunchGrab()
            }

            else
            {
                timePct = 0f;
               
               myHands[0].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.blue, 1f);
                myHands[1].GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.blue, 1f);
                //Player dash grab goes here
            }

        }

    }
}
