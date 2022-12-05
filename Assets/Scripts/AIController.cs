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
        Player = GameObject.FindGameObjectWithTag("Player");
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
    }
}
