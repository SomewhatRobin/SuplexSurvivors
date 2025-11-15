using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float rollForce;
    public float speed;
    public Vector3 myWay;
    public float vecMag = 0f;
    public Vector3 armWay;
    public Transform bananba;
    // [SerializeField]
    //{ get; private set; }
    private Rigidbody rb;
    public GameObject hidArms;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myWay = new Vector3(0, 0, 0);
        armWay = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rollForce = speed;
        Stroll();
        SpinArms();
    }

    private void SpinArms()
    {
        //There's a castarm in the scene to fix the arms rotating on y instead of z
        //Fix this so it actually spins arms
        // bananba.localRotation = Quaternion.Euler(-151.6f,0f,bananba.rotation.y);
        //Sets arm rotation to go on xy instead of xz, hopefully fixing this
        armWay.x = myWay.x;
        armWay.y = myWay.z;
        hidArms.transform.localRotation = Quaternion.LookRotation(armWay, Vector3.forward); 
    }

    //Stroll now has movement that accounts for diagonals on Keyboard

    private void Stroll()
    {
        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");
        vecMag = Mathf.Sqrt((xDir * xDir) + (zDir * zDir)); //Calculates the Magnitude of the vector

        if ((xDir * xDir) + (zDir * zDir) > 1.05f) //If the value of the input has it outside a circle w/ radius 1.05 [IF THEY ARE ON KB]
        {

            //Sets xDir and zDir to be (Direction / Magnitude), so total move speed is 1.
            //TODO: Shorten this, it doesn't need the if else anymore
            if (xDir > 0)
            {
                xDir = xDir/vecMag;
            }
            else
            {
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
