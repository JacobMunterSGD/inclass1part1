using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptAssignment : MonoBehaviour
{
    Vector2 inputDirectionX;
    Vector2 inputDirectionY;
    public float force;
    public Rigidbody2D rigidBody;
    public float jumpForce;
    bool jumpDown;

    bool isOnGround;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float maxHorizontalSpeed;


    void Update()
    {

        isOnGround = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.4f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        inputDirectionX = new Vector2(Input.GetAxis("Horizontal"), 0);
        inputDirectionY = new Vector2(0, Input.GetAxisRaw("Vertical"));

        jumpDown = Input.GetKeyDown(KeyCode.Space);

        //Debug.Log(Input.GetKeyDown(KeyCode.Space));

        //Debug.Log(inputDirectionY);

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpDown = true;
            Debug.Log(jumpDown);
        }
        else
        {
            jumpDown = false;
        }*/



    }

    void FixedUpdate()
    {
        if (rigidBody.velocity.magnitude < maxHorizontalSpeed && rigidBody.velocity.magnitude > -maxHorizontalSpeed)
        {
            rigidBody.AddForce(inputDirectionX * force * Time.deltaTime);
        }

        

        if (jumpDown == true && isOnGround == true)
        {

            //rigidBody.AddForce(inputDirectionY * jumpForce * Time.deltaTime);
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
