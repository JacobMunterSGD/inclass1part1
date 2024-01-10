using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mover : MonoBehaviour
{

    public float speed = 3f;
    public GameObject missilePrefab;
    public Transform spawn;

    void Update()
    {

        float direction = Input.GetAxis("Horizontal");
        transform.Translate(speed * direction * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            //Instantiate(missilePrefab);
            Instantiate(missilePrefab, spawn.position, spawn.rotation);

        }


    }
}
