using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] float Speed = 30f;
    private Rigidbody rb;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     
           rb.AddForce(Vector3.forward * -Speed * Time.deltaTime);
        
    }
}
