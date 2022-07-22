using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstalceGenerator : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject cube;
    ShuffleTransformPoints script;
    private void Awake()
    {
        script = cube.GetComponent<ShuffleTransformPoints>();
    }
    private void Update()
    {

        Instantiate(obstacle, script.pos, Quaternion.identity) ; //this is working now, but for just one obstacle

  }

