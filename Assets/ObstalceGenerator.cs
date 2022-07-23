using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstalceGenerator : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject cube;
    ShuffleTransformPoints script;  //instance of the script
    public Vector3 position;
    public GameObject spawnPoint;
    private void Awake()
    {
        script = cube.GetComponent<ShuffleTransformPoints>();  //the script is on this object, CUBE
    }
    private void FixedUpdate()
    {
        spawnPoint = script.spawnPoint; 
          Instantiate(obstacle, spawnPoint.transform.position, Quaternion.identity); //this is working now, but for just one obstacle  //at this point, instantiate OBSTACLE
    }
  }


