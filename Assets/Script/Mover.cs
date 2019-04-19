using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform destinationSpot;
    public Transform originSpot;
    public float speed = 5.0f;
    public float pauseDuration = 5.0f;

    private float platformTimer = 0.0f;
    private bool Switch = false;

    void FixedUpdate()
    {
        // For these 2 if statements, it's checking the position of the platform.
        // If it's at the destination spot, it sets Switch to true.
        if (transform.position == destinationSpot.position && Switch == false)
        {
            Switch = true;
            platformTimer = 0.0f;

        }
        if (transform.position == originSpot.position && Switch == true)
        {
            Switch = false;
            platformTimer = 0.0f;

        }

        // If Switch becomes true, it tells the platform to move to its Origin.
        if (Switch)
        {
            // If the platformTimer is more than the pauseDuration then start 
            // moving the platform else make the platformTImer count up.
            if (platformTimer >= pauseDuration)
            {
                transform.position = Vector3.MoveTowards(transform.position, originSpot.position, speed * Time.deltaTime);
            }
            else
            {
                platformTimer += Time.deltaTime;
            }
        }
        else
        {
            // If Switch is false, it tells the platform to move to the destination.

            // If the platformTimer is more than the pauseDuration then start 
            // moving the platform else make the platformTImer count up.
            if (platformTimer >= pauseDuration)
            {
                transform.position = Vector3.MoveTowards(transform.position, destinationSpot.position, speed * Time.deltaTime);
            }
            else
            {
                platformTimer += Time.deltaTime;
            }
        }
    }
}

