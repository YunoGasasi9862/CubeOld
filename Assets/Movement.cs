using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public float JumpSpeed = 5f;
    bool isOntheGround = false;
    Rigidbody rb;
    public int MaxNumberofJumps = 3;
     public Text jumps;

    GameManager gameManager;
    public Text Over;
    public Text Coincount;
    bool isPaused = false;
    public Text Restart;
    float thrustspeed = 2f;

     int coinCount=0;

    public Text HS;
    public AudioSource sound;
    public AudioSource collisionsound;
    public GameObject particles;


    public GameObject text;

  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindWithTag("gameManager").GetComponent<GameManager>();
        Over = GameObject.Find("Canvas/GameOver").GetComponent<Text>(); //OMG THIS WORKED!!!!
        Restart = GameObject.Find("Canvas/Restart").GetComponent<Text>();

        HS = GameObject.Find("Canvas/HS").GetComponent<Text>();
        text = GameObject.Find("Canvas/BuyJumps");

    }

    // Update is called once per frame
    void Update()
    {

        float Horizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float Vertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;


        transform.Translate(Horizontal, 0, Vertical);
         if (!isPaused)
        {

            if (MaxNumberofJumps > 0)
            {
              if(Input.GetButtonDown("Jump") && isOntheGround)
                {
                    rb.AddForce(transform.up * JumpSpeed, ForceMode.Impulse);
                    MaxNumberofJumps--;
                    isOntheGround = false;
                }


                if (!isOntheGround)
                {
                    if (Input.GetKey(KeyCode.H))
                    {
                        rb.AddForce(transform.forward * thrustspeed, ForceMode.Impulse);
                    }

                }


            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                text.SetActive(true);

            }
            if (MaxNumberofJumps==0)
            {
                if(HS!=null)
                    Destroy(HS.gameObject);
            }


            //shows number of jumps left
            showJump();
        }


        if(isPaused && Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 1;
            isPaused = false;
            Restart.gameObject.SetActive(false);
            Over.gameObject.SetActive(false);
            gameManager.GameOver(); //restarting the game

        }

        Coincount.text = coinCount.ToString("0");

    }

    void showJump()
    {
        jumps.text = MaxNumberofJumps.ToString("0");
    }

    private void OnCollisionEnter(Collision collision)  //for JUMPS IMMA USE COLLISION DETECTOR NOW. THIS IS SO MUCH FUCKING BETTER!!!
    {
        if (collision.collider.tag == "Ground")
        {
            isOntheGround = true;
        }

        if (collision.collider.tag == "Obstacle")
        {
            GameEndChecK();
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
            Instantiate(particles, collision.collider.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }

    }

    void GameEndChecK()
    {
        isPaused = true;
        Over.gameObject.SetActive(true);
        Restart.gameObject.SetActive(true);
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
}
