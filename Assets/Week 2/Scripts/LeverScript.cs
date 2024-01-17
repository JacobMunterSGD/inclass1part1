using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{

    public GameObject door;

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (door.activeInHierarchy)
        {
            door.SetActive(false);
        }
        else if (door.activeInHierarchy == false)
        {
            door.SetActive(true);
        }
    }
}
