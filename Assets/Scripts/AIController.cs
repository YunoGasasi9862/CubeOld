using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] float Speed = 30f;
    [SerializeField] Animator anim;
    private Rigidbody rb;
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

            if (Vector3.Distance(transform.position, Player.transform.position) < 15f)
            {
                rb.velocity = new Vector3(0, 0, 0);
                anim.SetBool("KeepFlying", true);

            }
        }else
        {
            Player = GameObject.FindGameObjectWithTag("Player");

        }

    }
}
