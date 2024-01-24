using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostScript : MonoBehaviour
{
    public GameObject car;
    public Rigidbody2D carRigidBody;

    float steering;
    float acceleration;
    void Update()
    {

        steering = -(Input.GetAxis("Horizontal"));
        acceleration = Input.GetAxis("Vertical");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 force = transform.up * 10000 * acceleration * Time.deltaTime;
        Debug.Log(force);
        carRigidBody.AddForce(force);
    }
}
