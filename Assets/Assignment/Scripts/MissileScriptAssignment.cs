using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MissileScriptAssignment : MonoBehaviour
{
    public float speed;
    Vector2 missileDirection;
    Vector2 inputDirection;

    float inDir2;

    public Transform launchTransform;

    //public Transform launcherTransformation;

    Rigidbody2D rigidBody;

    private void Start()
    {
        launchTransform = GameObject.FindGameObjectWithTag("Launcher").GetComponent<Transform>();

        rigidBody = GetComponent<Rigidbody2D>();

        //inputDirection.x = Input.GetAxisRaw("Horizontal");
        //inputDirection.y = Input.GetAxisRaw("Vertical");

        inDir2 = launchTransform.transform.rotation.z;
        //UnityEngine.Debug.Log(inDir2);


        if (inDir2 == 0)
        {
            
            missileDirection = new Vector2(-speed, 0);
            //UnityEngine.Debug.Log("left");
        }

        else if (inDir2 == 1)
        {
            missileDirection = new Vector2(speed, 0);
            //UnityEngine.Debug.Log("right");
        }

        else if (inDir2 > 0 && inDir2 < 1)
        {
            missileDirection = new Vector2(0, -speed);
            //UnityEngine.Debug.Log("down");
        }

        else if (inDir2 <= -.5)
        {
            missileDirection = new Vector2(0, speed);
            //UnityEngine.Debug.Log("up");
        }
    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + missileDirection);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);

    }
}
