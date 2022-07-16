using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float MouseSensitivity = 100f;
    public float speed = 20f;
    public float JumpSpeed = 5f;
    bool isOntheGround = false;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");//for X movement  (THESE ARE WAY FUCKING BETTER) AXIS
        float Vertical = Input.GetAxis("Vertical");//for Z movement

        Horizontal = Horizontal* speed * Time.deltaTime;
        Vertical = Vertical * speed * Time.deltaTime;

        /* transform.Translate(Horizontal, 0, Vertical); */ //initializing it with new Vector3 or you can simply use Horizontal, 0, Vertical too
        transform.Translate(Horizontal, 0, Vertical);


        if (Input.GetButtonDown("Jump") && isOntheGround) //GetButtondown is better
        {
            rb.AddForce(transform.up * JumpSpeed, ForceMode.Impulse);  //transform.up works :))
            isOntheGround = false; //THIS ONE IS MORE SOPHISTICATED. EVEN WE WERE CHECKING IF THE PLAYER IS ON THE GROUND OR NOT

        }

      
       
    }

    private void OnCollisionEnter(Collision collision)  //for JUMPS IMMA USE COLLISION DETECTOR NOW. THIS IS SO MUCH FUCKING BETTER!!!
    {
        if(collision.collider.tag=="Ground")
        {
            isOntheGround = true;
        }
    }
}
