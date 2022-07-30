using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOsbtacle : MonoBehaviour
{
     Transform Rightbound;
     Transform LeftBound;
    public GameObject ground;
     Vector3 position;
    public bool left, right;
    // Update is called once per frame

    private void Awake()
    {
        ground = GameObject.FindWithTag("Ground");
        Rightbound = ground.transform.GetChild(8);
        LeftBound = ground.transform.GetChild(9); //this is how you get childs
        //randomize the movement here!!!

        position = Rightbound.position;

    }
    void Update()
    {


        transform.Translate(position * Time.deltaTime);

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "BoundLeft")
        {
            position = Rightbound.position;
        }
        if (other.tag == "BoundRight")
        {
            position = LeftBound.position;

        }
    }

    
}
