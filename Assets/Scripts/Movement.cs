using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 20f;
    [SerializeField] float JumpSpeed = 5f;
    [SerializeField] Rigidbody rb;
    [SerializeField] int MaxNumberofJumps = 3;
    [SerializeField] Text jumps;

    [SerializeField] GameManager gameManager;
    [SerializeField] Text Coincount;
    [SerializeField] bool isPaused = false;
    [SerializeField] float thrustspeed = 30f;

    [SerializeField] int coinCount=0;

    [SerializeField] GameObject HS;
    [SerializeField] AudioSource sound;
    [SerializeField] AudioSource collisionsound;
    [SerializeField] GameObject particles;


    [SerializeField] GameObject BuyJumps;

    [SerializeField] bool CoinAchieved;

    [SerializeField] LayerMask ground;
     private CapsuleCollider col;


    [SerializeField] GameObject CanvasRestart;
    [SerializeField] GameObject HUD;

    [SerializeField] Animator anim;

    private float Horizontal;
    private float Vertical;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindWithTag("gameManager").GetComponent<GameManager>();
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {


         Horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

         Vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(Horizontal, 0, Vertical);
        CheckAnimation();



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
                        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, thrustspeed);
                    }


            if (Input.GetKeyDown(KeyCode.I))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                BuyJumps.gameObject.SetActive(true);
               

            }

          
            if (MaxNumberofJumps==0)
            {
                if (HS != null)
                    HS.gameObject.SetActive(false);
            }
            else
            {

                    HS.gameObject.SetActive(true);

            }

            DisableCoinText();

            //shows number of jumps left
            showJump();
        }


        if(isPaused && Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 1;
            isPaused = false;
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
            CoinAchieved = true;  //i replaced the choin Achieved to here because this will not be called every frame. Which means, only once :) so it worked!!

        }

    }

    void DisableCoinText()  //fix this tomorrow!!!
    {
        if (CoinAchieved)
        {
            BuyJumps.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CoinAchieved = false;
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


        if(rb.velocity.y >=0.1f)
        {
            anim.SetInteger("AnimationPar", 2);

        }else if(rb.velocity.y <=-.1f)
        {
            anim.SetInteger("AnimationPar", 3);

        }


    }
}
