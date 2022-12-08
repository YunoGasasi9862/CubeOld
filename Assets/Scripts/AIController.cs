using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] float Speed = 30f;
    [SerializeField] Animator anim;
    private Rigidbody rb;
    private float Dotproduct;
    private float AinRad;
    private float AinDegrees;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("FlyForward"))
        {
            rb.AddForce(Vector3.forward * -Speed * Time.deltaTime);
            
        }


        //calculate distance between
        if(Player!=null)
        {

            if (Vector3.Distance(transform.position, Player.transform.position) < 10f)
            {
                rb.velocity = new Vector3(0, 0, 0);
                anim.SetBool("KeepFlying", true);

                //rotate the dragon toward the Player
                Dotproduct = Vector3.Dot(transform.position, Player.transform.position);
                Dotproduct = Dotproduct / (transform.position.magnitude * Player.transform.position.magnitude);

                AinRad = Mathf.Acos(Dotproduct);

                AinDegrees = (AinRad * (180 / Mathf.PI) * 2);

                if(Player.transform.position.x <= transform.position.x)
                {
                    AinDegrees = 180 + AinDegrees ;
                }else
                {
                    AinDegrees = 180- AinDegrees; //to preserve the first 180 degrees

                }


                Debug.Log(AinDegrees);

                transform.localRotation = Quaternion.AngleAxis(AinDegrees, Vector3.up); // on yaxis


            }
        }else
        {
            Player = GameObject.FindGameObjectWithTag("Player");

        }

    }
}
