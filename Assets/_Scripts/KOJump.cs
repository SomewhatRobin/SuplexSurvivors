using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KOJump : MonoBehaviour
{
    private float timeGo = 0f;
    private float launchToX, launchToZ;


    private void OnEnable()
    {
        //Randomized value between -.016 and .016, and -.022 and .022, respectively
        launchToX = Random.value * .032f - .016f;
        launchToZ = Random.value * .044f - .022f;
    }

    // Update is called once per frame
    void Update()
    {
        timeGo += Time.deltaTime;

        transform.position = new Vector3(transform.position.x + (launchToX), 
                                         transform.position.y + (-.35f * timeGo) * (timeGo - 0.7f), 
                                         transform.position.z + (launchToZ)); 
    }
}
