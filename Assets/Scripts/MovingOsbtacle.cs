using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovingOsbtacle : MonoBehaviour
{
    // Transform Rightbound;
    // Transform LeftBound;
    //public Transform ground;
    //float number;
   [SerializeField] float speed=10f;
     //Vector3 position;

    [SerializeField] GameObject[] points;
    [SerializeField] int Index = 0;
       // Update is called once per frame


    //CHANGE THIS WITH TRIG FUCNTION!!!! (Make it more decent!) as its oscillating, use the TRIGNOMETRY FUCNTION!!
    private void Start()
    {
        ////I FUCKING FIXED IT!! IM IN TEARS WALLAHI!!!. RATHER THAN USING GAMEOBJECT GROUND, I USED TRANFORM :))

        //    Rightbound = ground.GetChild(8);

        //    LeftBound = ground.GetChild(9);



        //    number = Random.Range(0, 2);//this checks for 0, 1 and assign the position randomly
        //    speed = Random.Range(1, 4);  //his checks the speed of each cube

        //    //speed variable gives variable speed to the spawned obstacle!
        //    //number generates a value between 0 and 1, and use it to give either right bound or left bound


        //    if (number == 0)
        //    {
        //        position = Rightbound.position;

        //    }
        //    else if (number == 1)
        //    {
        //        position = LeftBound.position;

        //    }
    
    }
    void Update() //fixed update worked for translating the objects left and right continuously
        //the regular update function didn't work !!
    {


        // transform.Translate(position * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, transform.parent.GetChild(Index).transform.position) < 0.1f) //this checks for the distances between the two vectors (vector multiplication and stuff, etc)
        {
            Index++;

            if(Index >= points.Length)  //so it stays in loop
            {
                Index = 0;//turn it back to zero!
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, transform.parent.GetChild(Index).transform.position, speed * Time.deltaTime); // I FORGOT TO ASSIGN THE VALUE!!
        Debug.Log(Index);       

    }

    private void OnTriggerEnter(Collider other)
    {

            //if (other.tag == "BoundLeft")
            //{
            //    position = Rightbound.position;  //this conclision checks if the tag is boundleft,
            //                                     if it is boundleft, it will invert the position to right
            //}
            //if (other.tag == "BoundRight")
            //{
            //    position = LeftBound.position;

            //}

    }







}
