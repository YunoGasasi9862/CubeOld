using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetarRotate : MonoBehaviour
{
    private float speed = 20;
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
