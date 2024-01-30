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

    public GameObject missilePrefab;
    public Transform spawn;


    void Update()
    {

        isOnGround = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 1f), CapsuleDirection2D.Horizontal, 0, groundLayer);

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

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {

            //rigidBody.AddForce(inputDirectionY * jumpForce * Time.deltaTime);
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);

        }


        // shoot missile
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Instantiate(missilePrefab, spawn.position, spawn.rotation);
        }


    }

    void FixedUpdate()
    {
        if (rigidBody.velocity.magnitude < maxHorizontalSpeed && rigidBody.velocity.magnitude > -maxHorizontalSpeed)
        {
            rigidBody.AddForce(inputDirectionX * force * Time.deltaTime);
        }

        

        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
