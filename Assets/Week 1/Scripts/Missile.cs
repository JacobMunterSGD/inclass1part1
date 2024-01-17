using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    public float speed;
    Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //transform.Translate(speed * Time.deltaTime, 0, 0);

    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(speed * Time.deltaTime, 0);
        rigidBody.MovePosition(rigidBody.position + direction);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("missile collision");
        Destroy(gameObject);
    }

}
