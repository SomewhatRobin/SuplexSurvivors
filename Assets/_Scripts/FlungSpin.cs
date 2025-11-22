using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlungSpin : MonoBehaviour
{
   
    public float spinSpeed = 0.2f;


    // Update is called once per frame
    void Update()
    {

        transform.Rotate(transform.localRotation.x, transform.localRotation.y + spinSpeed, transform.localRotation.z);

    }
}
