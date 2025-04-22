using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtShip : MonoBehaviour
{
    [Header("Target Settings")]
    [Tooltip("The GameObject the camera should look at")]
    public Transform target;

    [Header("Position Settings")]
    [Tooltip("Offset from the target's position")]
    public Vector3 offset = new Vector3(0, 0, -10);

    [Header("Smooth Follow")]
    [Tooltip("Should the camera follow smoothly?")]
    public bool smoothFollow = true;
    [Tooltip("Follow speed when using smooth movement")]
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("No target assigned for camera to follow!");
            return;
        }

        // Calculate target position with offset
        Vector3 desiredPosition = target.position + offset;

        // Handle camera positioning
        if (smoothFollow)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = desiredPosition;
        }

        // Make camera look at the target
        transform.LookAt(target);
    }
}