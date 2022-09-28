using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundSun : MonoBehaviour
{

    float angle = 0;
    void Update()
    {
        transform.position = new Vector3(transform.parent.position.x +100 * Mathf.Sin(angle), transform.position.y, transform.parent.position.z + 100* Mathf.Cos(angle));
        angle += .01f;

        if(angle>360)
        {
            angle = 0;
        }

       
    }


    

}
