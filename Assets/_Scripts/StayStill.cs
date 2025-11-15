using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayStill : MonoBehaviour
{
    public Vector3 stuckHere = new Vector3 (0f, 0f, 0f);

    // The rotation is constantly set to match what is set in the editor
    void Update()
    {
        transform.rotation = Quaternion.Euler(stuckHere.x, stuckHere.y, stuckHere.z);
    }
}
