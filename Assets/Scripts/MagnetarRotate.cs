using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetarRotate : MonoBehaviour
{
    [SerializeField] float speed = 30;
  

  
    void Update()
    {

     
            transform.Rotate(speed * Time.deltaTime, 0,0);

        
    }
}
