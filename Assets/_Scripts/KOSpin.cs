using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KOSpin : MonoBehaviour
{
    public float spinSpeed = 0.2f;
    public float spinSpeed2 = 0.2f;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(transform.localRotation.x, transform.localRotation.y + spinSpeed, transform.localRotation.z + spinSpeed2);

    }
}
