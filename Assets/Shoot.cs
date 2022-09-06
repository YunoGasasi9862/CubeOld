using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float shootingspeed = 50f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, shootingspeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            //add explosion animation
        }
    }
}
