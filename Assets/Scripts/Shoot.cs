using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float shootingspeed = 50f;
    [SerializeField] GameObject Anim;
    Vector3 pos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = transform.position;

    }
    void Update()
    {

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, shootingspeed);

        transform.position += transform.up * Mathf.Sin(Time.time * 10f) * .1f;
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
            GameObject animation = Instantiate(Anim, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);

           
        }
    }
}
