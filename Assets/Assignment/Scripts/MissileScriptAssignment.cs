using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MissileScriptAssignment : MonoBehaviour
{
    public float speed;
    Vector2 missileDirection;
    //Vector2 inputDirection;

    float inDir2;

    public Transform launchTransform;

    //public Transform launcherTransformation;

    Rigidbody2D rigidBody;

    public GameObject explosionPrefab;

    bool missileMode = true;

    public Transform player;

    public GameObject circle;
    float growthSpeed = 10;
    float shrinkSpeed = -2;
    bool growing = true;

    public Collider2D coll;

    public static Vector2 blastDirection;



    private void Start()
    {
        launchTransform = GameObject.FindGameObjectWithTag("Launcher").GetComponent<Transform>();

        

        rigidBody = GetComponent<Rigidbody2D>();



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
        if (missileMode)
        {
            rigidBody.MovePosition(rigidBody.position + missileDirection);
        }
        else
        {
            if (circle.transform.localScale.x < 4 && growing)
            {
                circle.transform.localScale += new Vector3(growthSpeed, growthSpeed, 0) * Time.deltaTime;
            }
            else
            {
                growing = false;
            }

            if (circle.transform.localScale.x > 0 && growing == false)
            {
                circle.transform.localScale += new Vector3(shrinkSpeed, shrinkSpeed, 0) * Time.deltaTime;
            }
            else if (circle.transform.localScale.x < 0 && growing == false)
            {
                Destroy(gameObject);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        missileMode = false;
        coll.enabled = !coll.enabled;

        //explosion
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        blastDirection = player.position - circle.transform.position;
        //UnityEngine.Debug.Log("original blast " + blastDirection);

        //Instantiate(explosionPrefab);
        //Destroy(gameObject);

    }
}
