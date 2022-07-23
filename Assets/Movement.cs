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
   public bool Mode1Automatic;
   public bool Mode2Manual;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        CheckforMode();
        float Horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float Vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        /* transform.Translate(Horizontal, 0, Vertical); */ //initializing it with new Vector3 or you can simply use Horizontal, 0, Vertical too
        transform.Translate(Horizontal, 0, Vertical);     
        if(Input.GetButtonDown("Jump") && isOntheGround)
                {

                     rb.AddForce(transform.up * speed, ForceMode.Impulse);
                    isOntheGround = false;
                }

       


    }

    void CheckforMode()
    {
        if (Input.GetKeyDown(KeyCode.M) && Mode1Automatic)
        {
            Mode1Automatic = false;
            Mode2Manual = true;
        }
        if (Input.GetKeyDown(KeyCode.M) && Mode2Manual)
        {
            Mode1Automatic = true;
            Mode2Manual = false;
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
