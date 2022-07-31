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
        LeftBound = ground.transform.GetChild(9);
        CheckPos();

    }
    void Update()
    {
        transform.Translate(position * 2* Time.deltaTime);
        //do something else now, make th scene beautiful!

    }

    void CheckPos()
    {
        float ran = Random.Range(0, 1);

        switch (ran)
        {
            case 0:
                position = Rightbound.position;
                break;

            case 1:
                position = LeftBound.position;
                break;
        }

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
