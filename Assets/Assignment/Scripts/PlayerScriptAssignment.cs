using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptAssignment : MonoBehaviour
{
    Vector2 inputDirectionX;
    Vector2 inputDirectionY;
    public float force;
    public Rigidbody2D rigidBody;

    public float maxHorizontalSpeed;


    void Update()
    {

        inputDirectionX = new Vector2(Input.GetAxis("Horizontal"), 0);
        inputDirectionY = new Vector2(0, Input.GetAxis("Vertical"));

    }

    void FixedUpdate()
    {
        if (rigidBody.velocity.magnitude < maxHorizontalSpeed && rigidBody.velocity.magnitude > -maxHorizontalSpeed)
        {
            rigidBody.AddForce(inputDirectionX * force * Time.deltaTime);
        }

    }
}
