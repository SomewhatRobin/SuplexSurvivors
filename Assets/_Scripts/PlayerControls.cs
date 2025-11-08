using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float rollForce;
    public float speed;
    public Vector3 myWay;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myWay = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rollForce = speed;
        Stroll();
    }

    //Stroll now has movement that accounts for diagonals on Keyboard
    
    private void Stroll()
    {
        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");
        if ( (xDir*xDir)+(zDir*zDir) > 1.25f) //If the value of the input has it outside a circle w/ radius 1.25 [IF THEY ARE ON KB]
        {
            //Sets xDir and zDir to be (sqrt(2) / 2), [so total move speed is 1-ish]
            //TODO: Make this also work with non-up right directions
            if (xDir > 0)
            {
                xDir = 0.7071f;
            }
            else
            {
                xDir = -0.7071f;
            }

            if (zDir > 0) 
            {
                zDir = 0.7071f;
            }
            else
            {
                zDir = -0.7071f;
            }
        }

        myWay.x = xDir;
        myWay.z = zDir;

        transform.position += myWay * speed * Time.deltaTime;

    }

}
