using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public float JumpSpeed = 5f;
    bool isOntheGround = false;
    Rigidbody rb;
    int MaxNumberofJumps = 3;
     public Text jumps;

    GameManager gameManager;
    public Text Over;
    bool isPaused = false;
    public Text Restart;
    float thrustspeed = 3f;

    public bool headstart=true;
    public Text HS;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindWithTag("gameManager").GetComponent<GameManager>();
        Over = GameObject.Find("Canvas/Panel/GameOver").GetComponent<Text>(); //OMG THIS WORKED!!!!
        Restart = GameObject.Find("Canvas/Panel/Restart").GetComponent<Text>();
        HS = GameObject.Find("Canvas/Panel/Headstart").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {


            float Horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float Vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

            transform.Translate(Horizontal, 0, Vertical);

        if (!isPaused)
        {

            if (MaxNumberofJumps > 0)
            {
                if (Input.GetButtonDown("Jump") && isOntheGround)
                {
                    rb.AddForce(transform.up * JumpSpeed, ForceMode.Impulse);
                    isOntheGround = false;
                    MaxNumberofJumps--;
                }
            }

            if (!isOntheGround)
            {
                    if (Input.GetKey(KeyCode.H))
                    {

                        rb.AddForce(transform.forward * thrustspeed, ForceMode.Impulse);
                    }




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

        }
        if (collision.collider.tag=="Fall")
        {
            GameEndChecK();
        }

    }

    void GameEndChecK()
    {
        isPaused = true;
        Over.gameObject.SetActive(true);
        Restart.gameObject.SetActive(true);
        Time.timeScale = 0;

    }

}
