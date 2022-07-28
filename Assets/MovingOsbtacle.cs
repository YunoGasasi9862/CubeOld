using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOsbtacle : MonoBehaviour
{
    public Transform Rightbound;
    public Transform LeftBound;
    public GameObject ground;

    // Update is called once per frame

    private void Awake()
    {
        ground = GameObject.FindWithTag("Ground");
        Rightbound = ground.transform.GetChild(8);
        LeftBound = ground.transform.GetChild(9); //this is how you get childs

    }
    void Update()
    {
        
    }
}
