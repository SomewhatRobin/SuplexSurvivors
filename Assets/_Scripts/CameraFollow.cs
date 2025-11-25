using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed = 5.0f;
    public float yDistance = 17.57f;
    public float allowableOffset = 3.0f;

    public float xOffset = -4.0f;
    public float zOffset = -10.0f;

   
    public GameObject player;

    // Improvements to consider:
    // - Easing movement at start and end
    // - Catching up more quickly if player is too far from center


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position + Vector3.right * xOffset + Vector3.up * yDistance + Vector3.forward * zOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position + Vector3.up * yDistance) > allowableOffset)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position 
                + Vector3.right * xOffset
                + Vector3.up * yDistance
                + Vector3.forward * zOffset, speed * Time.deltaTime);
        }

        Vector3 pos = transform.position;


        pos.y = player.transform.position.y + yDistance;

        transform.position = pos;

    }
}
