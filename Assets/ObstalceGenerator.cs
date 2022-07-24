using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstalceGenerator : MonoBehaviour
{
    public GameObject obstacle;
   
    private void Update()
    {
          Instantiate(obstacle, transform.position, Quaternion.identity); //this is working now, but for just one obstacle  //at this point, instantiate OBSTACLE
        Destroy(gameObject, 3f);
    }
  }


