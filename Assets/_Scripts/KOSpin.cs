using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KOSpin : MonoBehaviour
{
    public float spinSpeed = 0.2f;
    public float spinSpeed2 = 0.2f;

    void OnEnable()
    {
        if (transform.parent.eulerAngles.x < 55) //Slamboxes spawn in Ko'd enemies at below 60 deg
        {
            //And make enemies spin faster
            spinSpeed += 1.2f;
            spinSpeed2 += 12.1f;
        }
      
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(transform.localRotation.x, transform.localRotation.y + spinSpeed, transform.localRotation.z + spinSpeed2);

    }
}
