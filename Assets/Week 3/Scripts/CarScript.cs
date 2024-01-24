using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{

    public float steeringSpeed;
    public float forwardSpeed;
    public float maxSpeed;

    public Rigidbody2D rigidBody;

    float steering;
    float acceleration;


    void Update()
    {

        steering = -(Input.GetAxis("Horizontal"));
        acceleration = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        rigidBody.AddTorque(steering * steeringSpeed * Time.deltaTime);

        Vector2 force = transform.up * forwardSpeed * acceleration * Time.deltaTime;

        if (rigidBody.velocity.magnitude < maxSpeed)
        {

            rigidBody.AddForce(force);

        }

    }
}
