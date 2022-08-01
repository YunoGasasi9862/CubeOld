using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOsbtacle : MonoBehaviour
{
     Transform Rightbound;
     Transform LeftBound;
    public GameObject ground;
    float number;
    float speed;
     Vector3 position;
    
       // Update is called once per frame

    private void Awake()
    {
        ground = GameObject.FindWithTag("Ground");

        Rightbound = ground.transform.GetChild(8); //getchild function gets a child object that is 8th, and use its transform!
        LeftBound = ground.transform.GetChild(9);

        number = Random.Range(0, 2);//this checks for 0, 1 and assign the position randomly
        speed = Random.Range(1, 4);  //his checks the speed of each cube

        //speed variable gives variable speed to the spawned obstacle!
        //number generates a value between 0 and 1, and use it to give either right bound or left bound
       
        
        if(number==0)
        {
            position = Rightbound.position;

        }
        else if(number==1)
        {
            position = LeftBound.position;

        }

    }
    void FixedUpdate()
    {
        transform.Translate(position * speed * Time.deltaTime);
        //do something else now, make th scene beautiful!

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
