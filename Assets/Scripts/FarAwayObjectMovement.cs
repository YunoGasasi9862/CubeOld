using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarAwayObjectMovement : MonoBehaviour
{
    private float angle = 0;
    void Update()
    {
        angle+=.01f;
        transform.position = new Vector3(transform.parent.position.x + 30000 * Mathf.Sin(angle), transform.parent.position.y + 35000 * Mathf.Sin(angle) * Mathf.Cos(angle), transform.parent.position.z + 8000 * Mathf.Cos(angle));
        if (angle>360)
        {
            angle = 0;
        }    
    }
}
