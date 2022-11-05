using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 20f;
    [SerializeField] float JumpSpeed = 5f;
    [SerializeField] Rigidbody rb;
    [SerializeField] int MaxNumberofJumps = 3;
    private Text jumps;

    [SerializeField] GameManager gameManager;
    private Text Coincount;
    [SerializeField] bool isPaused = false;

    [SerializeField] int coinCount=0;

    [SerializeField] GameObject HS;
    [SerializeField] AudioSource sound;
    [SerializeField] AudioSource collisionsound;
    [SerializeField] GameObject particles;


    [SerializeField] LayerMask ground;
     private CapsuleCollider col;


    [SerializeField] GameObject CanvasRestart;
    [SerializeField] GameObject HUD;

    [SerializeField] Animator anim;

    [SerializeField] GameObject planet;

    private bool destroy = false;
    private Vector3 newLocation;
    private float Horizontal;
    private float Vertical;
    private GameObject temp=null;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindWithTag("gameManager").GetComponent<GameManager>();
        col = GetComponent<CapsuleCollider>();
        InstantiatePlanet();
        jumps = GameObject.Find("/HUD/Number").GetComponent<Text>();
        Coincount = GameObject.Find("/HUD/CoinCount").GetComponent<Text>();
        }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime ;

        Vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(Horizontal, 0, Vertical);

        CheckAnimation();
        CheckForSpace();


        if (!isPaused)
        {

            if (MaxNumberofJumps > 0)
            {
                if (Input.GetButtonDown("Jump") && isOnetheGround())
                {
                    rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
                    MaxNumberofJumps--;
                }


            }
                   if (Input.GetKey(KeyCode.H))
                    {
                      anim.SetInteger("AnimationPar", 4);
                    }


            if (Input.GetKeyDown(KeyCode.I))
            {
                InreaseJumps();
               

            }


            //shows number of jumps left
            showJump();

            
        }

   

        if(isPaused && Input.GetKeyDown(KeyCode.F))
        {
            gameManager.Restart();
            Time.timeScale = 1;
            isPaused = false;
             //restarting the game

        }

        Coincount.text = coinCount.ToString("0");


      
    }

    void showJump()
    {
        jumps.text = MaxNumberofJumps.ToString("0");
    }
    private void OnCollisionEnter(Collision collision)  //for JUMPS IMMA USE COLLISION DETECTOR NOW. THIS IS SO MUCH FUCKING BETTER!!!
    {


        if (collision.collider.tag == "Obstacle")
        {
            GameEndChecK();
            gameManager.isOver = true;
            collisionsound.Play();


        }
        if (collision.collider.tag=="Fall")
        {
            GameEndChecK();
        }

        if(collision.collider.tag=="Coin")
        {
            coinCount++;
            Coincount.text = coinCount.ToString("0");
            sound.Play();
            GameObject part= Instantiate(particles, collision.collider.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(part, 5f);
        }
    }
    void GameEndChecK()
    {
        isPaused = true;

        Instantiate(CanvasRestart, transform.position, Quaternion.identity);
        HUD.SetActive(false);
        collisionsound.Play();
        Time.timeScale = 0;

    }
    public void InreaseJumps()
    {
        if (MaxNumberofJumps <= 3 && coinCount >= 3)
        {

            MaxNumberofJumps++;
            coinCount = coinCount - 3;

        }

    }


    private bool isOnetheGround()
    {

        return Physics.CapsuleCast(col.bounds.center, col.bounds.size, 0.1f, Vector2.down, 3f, ground);
    }

    void CheckAnimation()
    {
        if ( Horizontal >0 || Vertical > 0f)
        {
            anim.SetInteger("AnimationPar", 1);
        }
        else if ( Horizontal <0f || Vertical < 0f)
        {
            anim.SetInteger("AnimationPar", 1);

        }
        else
        {
            anim.SetInteger("AnimationPar", 0);
        }


        
        if(rb.velocity.y >=.1f)
        {
            anim.SetInteger("AnimationPar", 2);

        }else if(rb.velocity.y <=-.1f)
        {
            anim.SetInteger("AnimationPar", 3);
        }

    }

    void CheckForSpace()
    {
        

            if (transform.position.z >= temp.transform.position.z) //wtf THIS IS WORKING? but not the
                                                                     //but not the DistancE? FUCK YOU !!
            {
                Destroy(temp,5f);
                destroy = true;

            }

            if(destroy==true)
           {
             int posCheck = Random.Range(0, 2);
              if (posCheck == 0)
             {
                  newLocation.x = -70f;
               }
             else
             {
                 newLocation.x = 70f;
             }

            temp = Instantiate(planet, newLocation, Quaternion.identity);
            destroy = false;
          }
          


    }


    void InstantiatePlanet()
    {
        int posCheck = Random.Range(0, 2);
        if (posCheck == 0)
        {
            newLocation.x = -70f;
        }
        else
        {
            newLocation.x = 70f;
        }

        newLocation.y = 150f;
        newLocation.z = transform.position.z + 1000f;
        temp=Instantiate(planet, newLocation, Quaternion.identity);


    }
}
