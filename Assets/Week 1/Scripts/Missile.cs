using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    public float speed = 3f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

    }
}
