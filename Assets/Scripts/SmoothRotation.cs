using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotation : MonoBehaviour
{

    [Tooltip("Speed of rotation in degrees per second")]
    public float rotationSpeed = 90f; // Speed of rotation in degrees per second

    private bool isRotating = false;
    private Quaternion targetRotation;
    private Vector3 axis;

    // Start rotating the object
    public void Rotate(Vector3 rotationAxis, float degrees, bool clockwise)
    {
        if (!isRotating)
        {
            axis = rotationAxis.normalized;
            float direction = clockwise ? 1f : -1f;
            targetRotation = Quaternion.AngleAxis(direction * degrees, rotationAxis) * transform.rotation;
            isRotating = true;
        }
    }

    void Update()
    {
        if (isRotating)
        {
            // Rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Check if the target rotation has been reached
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                isRotating = false;
            }
        }
    }
}
