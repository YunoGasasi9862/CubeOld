using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovingOsbtacle : MonoBehaviour
{
     Transform Rightbound;
     Transform LeftBound;
    public GameObject ground;
    float number;
    float speed;
     Vector3 position;
    GameManager gameManager;
    public Text gameOver;
    bool isPaused;
    
       // Update is called once per frame

    private void Awake()
    {
        gameManager = GameObject.FindWithTag("gameManager").GetComponent<GameManager>();
        ground = GameObject.FindWithTag("Ground");

        Rightbound = ground.transform.GetChild(8);
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
    void FixedUpdate() //fixed update worked for translating the objects left and right continuously
        //the regular update function didn't work !!
    {
        transform.Translate(position * speed * Time.deltaTime);
        //do something else now, make th scene beautiful!

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "BoundLeft")
        {
            position = Rightbound.position;  //this conclision checks if the tag is boundleft, 
            //if it is boundleft, it will invert the position to right
        }
        if (other.tag == "BoundRight")
        {
            position = LeftBound.position;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Player")
        {
           gameOver.text = "Game Over";
            isPaused = true;

            if(isPaused)
            {
                Time.timeScale = 0;
            }



            //gameManager.GameOver();
        }
    }

}
