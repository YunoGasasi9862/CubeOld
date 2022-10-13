using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarAwayObjectMovement : MonoBehaviour
{
    private float angle = 0;
    void Update()
    {
        angle+=.01f;
        transform.position = new Vector3(transform.parent.position.x + 40000 * Mathf.Sin(angle) * 2, transform.parent.position.y + 35000 * Mathf.Sin(angle) * Mathf.Cos(angle) * 2, transform.parent.position.z + 12000 * Mathf.Cos(angle) * 3);
        if (angle>360)
        {
            angle = 0;
        }    
    }
}
