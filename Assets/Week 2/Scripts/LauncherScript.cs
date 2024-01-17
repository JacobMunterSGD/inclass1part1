using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherScript : MonoBehaviour
{

    public GameObject missilePrefab;
    public Transform spawn;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(missilePrefab, spawn.position, spawn.rotation);
    }
}
