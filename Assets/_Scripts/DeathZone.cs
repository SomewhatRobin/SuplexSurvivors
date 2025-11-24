using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void Update()
    {
        //Copied form Connect 4 DX, this will destroy an object if that object's y-position goes below -0.9f 
        if (transform.position.y < -0.9f )
        {
            Destroy(this.gameObject);
        }
    }
}
