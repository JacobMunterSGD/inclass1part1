using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherRotationScriptAssignment : MonoBehaviour
{

    Vector2 inputDirection;

    //public Transform trans;

    void Update()
    {
        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.y = Input.GetAxisRaw("Vertical");

        //if (inputDirection.x)
        //trans.rotation = new Vector3(0, 0, 1);
        //transform.rotation = Quaternion.Euler(0, 0, 30);

        if (inputDirection.x == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (inputDirection.x == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (inputDirection.y == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        if (inputDirection.y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }

    public Vector2 getDirection()
    {
        return inputDirection;
    }
}
