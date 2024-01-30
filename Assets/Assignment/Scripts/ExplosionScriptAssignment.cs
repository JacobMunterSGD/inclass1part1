using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScriptAssignment : MonoBehaviour
{

    public GameObject circle;
    float growthSpeed = 10;
    float shrinkSpeed = -2;

    bool growing = true;

    private void Start()
    {
        circle.transform.position = new Vector3(10, 5, 0);
    }

    // Update is called once per frame
    void Update()
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
