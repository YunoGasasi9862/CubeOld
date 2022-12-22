using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] float Speed;
    [SerializeField] Animator anim;
    private Rigidbody rb;
    private float Dotproduct;
    private float AinRad;
    private float AinDegrees;
    private bool Backward = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("FlyForwardCopy") && !Backward)
        {
            rb.AddForce(Vector3.forward * -Speed * Time.deltaTime);
            
        }


        //calculate distance between
        if(Player!=null)
        {

            if (Vector3.Distance(transform.position, Player.transform.position) < 20f && Vector3.Distance(transform.position, Player.transform.position)>10f && (transform.position.z > Player.transform.position.z))
            {
                Backward = false;

                rb.velocity = new Vector3(0, 0, 0);
                anim.SetBool("KeepFlying", true);

            


            }

            if(Vector3.Distance(transform.position, Player.transform.position)<10f && Vector3.Distance(transform.position, Player.transform.position)>4f && (transform.position.z > Player.transform.position.z))
            {
                //rotate the dragon toward the Player
                Dotproduct = Vector3.Dot(transform.position, Player.transform.position);
                Dotproduct = Dotproduct / (transform.position.magnitude * Player.transform.position.magnitude);

                AinRad = Mathf.Acos(Dotproduct);

                AinDegrees = (AinRad * (180 / Mathf.PI));

                transform.localRotation = Quaternion.AngleAxis(AinDegrees, Vector3.forward);


                if (Player.transform.position.x < transform.position.x)
                {
                    AinDegrees = 180 + AinDegrees;
                }
                else if (Player.transform.position.x > transform.position.x)
                {
                    AinDegrees = 180 - (AinDegrees); //to preserve the first 180 degrees

                }


                transform.localRotation = Quaternion.AngleAxis(AinDegrees, Vector3.up); // on yaxis
            }
         

            if (transform.position.z  - 3f< Player.transform.position.z)
            {
                Backward = true;
                anim.SetBool("KeepFlying", false);
                 float backwardSpeed = 400f;

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("FlyForward"))
                {
                    rb.AddForce(Vector3.forward * backwardSpeed * Time.deltaTime);

                }
              


            }


        }
        else
        {
            Player = GameObject.FindGameObjectWithTag("Player");

        }

    }
}
