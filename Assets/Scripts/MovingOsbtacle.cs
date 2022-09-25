using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovingOsbtacle : MonoBehaviour
{
    Transform Rightbound;
    Transform LeftBound;
    public Transform ground;
    float number;
    [SerializeField] float speed=5f;
     Vector3 position;

       // Update is called once per frame


    //CHANGE THIS WITH TRIG FUCNTION!!!! (Make it more decent!) as its oscillating, use the TRIGNOMETRY FUCNTION!!
    private void Start()
    {
        ////I FUCKING FIXED IT!! IM IN TEARS WALLAHI!!!. RATHER THAN USING GAMEOBJECT GROUND, I USED TRANFORM :))

        Rightbound = ground.GetChild(0);
        LeftBound = ground.GetChild(1);



        number = Random.Range(0, 2);//this checks for 0, 1 and assign the position randomly
        speed = Random.Range(1, 4);  //his checks the speed of each cube

        //speed variable gives variable speed to the spawned obstacle!
        //number generates a value between 0 and 1, and use it to give either right bound or left bound


        if (number == 0)
        {
            position.x = Rightbound.position.x;

        }
        else if (number == 1)
        {
            position.x = LeftBound.position.x;

        }

    }
    void FixedUpdate() //fixed update worked for translating the objects left and right continuously
        //the regular update function didn't work !!
    {

        transform.Translate(position.x * Time.deltaTime * speed, 0, 0);//YAYAYAY I FIXED IT IM GONNA CRY!!
  

    }
   
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("BoundLeft"))
        {
            position = Rightbound.position;  //this conclision checks if the tag is boundleft,
          //  if it is boundleft, it will invert the position to right
            }
        if (other.gameObject.CompareTag("BoundRight"))
        {
            position = LeftBound.position;

        }

    }







}
