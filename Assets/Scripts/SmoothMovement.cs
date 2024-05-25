using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    private bool isMoving = false;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float distance;
    private float speed;

    // Start moving the object
    public void Move(Vector3 moveAxis, float totalDistance, float moveSpeed, bool movePositive)
    {
        if (!isMoving)
        {
            initialPosition = transform.position;
            float direction = movePositive ? 1f : -1f;
            distance = totalDistance * direction;
            targetPosition = initialPosition + moveAxis.normalized * distance;
            speed = moveSpeed;
            isMoving = true;
        }
    }

    // Move the object by a specified amount and then return it to its original position
    public void MoveAndReturn(Vector3 moveAxis, float totalDistance, float moveSpeed)
    {
        if (!isMoving)
        {
            initialPosition = transform.position;
            targetPosition = initialPosition + moveAxis.normalized * totalDistance;
            speed = moveSpeed;
            isMoving = true;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Check if the target position has been reached
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                // Reverse the direction to return to the initial position
                Vector3 temp = targetPosition;
                targetPosition = initialPosition;
                initialPosition = temp;
            }

            // Check if the object has returned to the initial position
            if (Vector3.Distance(transform.position, initialPosition) < 0.01f)
            {
                isMoving = false;
            }
        }
    }
}

