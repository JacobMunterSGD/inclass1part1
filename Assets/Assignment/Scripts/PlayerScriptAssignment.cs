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

    Vector2 previousBlast;
    public float blastForce;
    //float maxBlast = 5;

    void Update()
    {

        isOnGround = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 1f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        inputDirectionX = new Vector2(Input.GetAxis("Horizontal"), 0);
        inputDirectionY = new Vector2(0, Input.GetAxisRaw("Vertical"));

        jumpDown = Input.GetKeyDown(KeyCode.Space);

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

        //var for previous dir value
        if (previousBlast != MissileScriptAssignment.blastDirection)
        {
            Vector2 tempBlast = new Vector2(MissileScriptAssignment.blastDirection.x, MissileScriptAssignment.blastDirection.y);
            /*if (tempBlast.x > maxBlast)
            {
                tempBlast.x = maxBlast;
            }
            if (tempBlast.y > maxBlast)
            {
                tempBlast.y = maxBlast;
            }
            if (tempBlast.x < -maxBlast)
            {
                tempBlast.x = -maxBlast;
            }
            if (tempBlast.y < -maxBlast)
            {
                tempBlast.y = -maxBlast;
            }*/
            //UnityEngine.Debug.Log("temp" + tempBlast);
            //UnityEngine.Debug.Log("magnitude " + tempBlast.magnitude);
            //float tempDistance = 1 / tempBlast.magnitude;
            rigidBody.AddForce(tempBlast.normalized * blastForce, ForceMode2D.Impulse);
            previousBlast = MissileScriptAssignment.blastDirection;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UnityEngine.Debug.Log("trigger works");
    }

}
