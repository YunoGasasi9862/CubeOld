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

    private float minScale=3, maxScale=5f;
    private bool scaling = false;
    private float _timingtrack;
    private float scaleValue;
    private float reduce = 0;
    private bool _reducedfinally = false;
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

    private void Update()
    {


        if(!scaling)
        {
            scaleValue = Scaling();
            scaling = true;
            _timingtrack = minScale;
        }


        if(scaling)
        {
            if (_timingtrack < scaleValue)
            {
                _timingtrack += Time.deltaTime;
             
               
                transform.localScale = new Vector3(transform.localScale.x,_timingtrack, transform.localScale.z);
            }
            else
            {
                reduce = _timingtrack;

                if (reduce > minScale)
                {
                    reduce -= Time.deltaTime;
                  
                    transform.localScale = new Vector3(transform.localScale.x, reduce, transform.localScale.z);
                 
                    _reducedfinally = true;
                }
            
            }

            if(_reducedfinally && reduce < minScale)
            {
                _reducedfinally = false;
                scaling = false;


            }


        }

      
    }
    void FixedUpdate() //fixed update worked for translating the objects left and right continuously
        //the regular update function didn't work !!
    {

        transform.Translate(position.x * speed * Time.deltaTime, 0, 0);//YAYAYAY I FIXED IT IM GONNA CRY!!
  
        //if(Vector2.distance())
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

    private float Scaling()
    {
        float value=minScale;
      
         value = Random.Range(minScale, maxScale);

        _timingtrack = minScale;
        return value;
    }





}
