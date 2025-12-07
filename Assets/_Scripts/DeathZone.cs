using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform movingPart; //This needs to be here so the moving part (Ko'd enemy's sprite) interacts with the script.


    void Update()
    {
        //Copied form Connect 4 DX, this will destroy an object if that object's y-position goes below -0.9f 
        if (transform.position.y < -0.9f || movingPart.position.y < -0.9f)
        {
            Destroy(this.gameObject);
        }
    }
}
