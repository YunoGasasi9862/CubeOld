using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOsbtacle : MonoBehaviour
{
     Transform Rightbound;
     Transform LeftBound;
    public GameObject ground;
     Vector3 position;
    // Update is called once per frame

    private void Awake()
    {
        ground = GameObject.FindWithTag("Ground");
        Rightbound = ground.transform.GetChild(8);
        LeftBound = ground.transform.GetChild(9); //this is how you get childs
        position = LeftBound.position;

    }
    void Update()
    {
        transform.Translate(position * Time.deltaTime);


    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name=="BoundLeft")
        {

        }
        if (collision.collider.name == "BoundLeft")
        {

        }
    }
}
