using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float rollForce;
    public float speed;
    public Vector3 myWay;
    public float vecMag = 0f;
    public float deadZone = 0.02f;
    public float targDist = 6f;
    public Vector3 armWay;

    // [SerializeField]
    //{ get; private set; }
    private Rigidbody rb;
    public GameObject hidArms;
    public GameObject armTango;

    public GrabsAndThrow grabThrows;

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
        //In the unity scene, the arms are attached to a parent object which has rotations set so this spins properly.

        //Sets arm rotation to go on xy instead of xz, preventing arms from spinning on the wrong axis
        //TODO: Fix this so arms don't snap to position, moving towards that position instead. Could do some time.deltaTime stuff with the armway calc?
        if (vecMag > deadZone && !grabThrows.btnPress)
        {
            //Mumbo jumbo to get the Arms to face the direction the player is moving in.
            armWay.x = myWay.x;
            armWay.y = myWay.z;
            hidArms.transform.localRotation = Quaternion.LookRotation(armWay, Vector3.forward);

            //Piggybacking off mumjumbo to get arm target to rotate with arms, at a set (editable!) distance from the player
            armTango.transform.localRotation = Quaternion.LookRotation(armWay, Vector3.forward);
            armTango.transform.position = transform.position + (Vector3.Normalize(myWay) * targDist);
        }
        else //Only changes aim direction if the player is moving, otherwise, arms should stay still
        {
            hidArms.transform.localRotation = Quaternion.LookRotation(armWay, Vector3.forward);
           // Don't update armTango here, the target does not move when the button is held.

            


        }
        
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

        if (vecMag > deadZone)
        {
            transform.position += myWay * speed * Time.deltaTime;
        }


    }

}
