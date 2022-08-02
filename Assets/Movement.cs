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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        float Horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(Horizontal, 0, Vertical);

        if(MaxNumberofJumps>0)
        {
           if (Input.GetButtonDown("Jump") && isOntheGround)
            {
                rb.AddForce(transform.up * JumpSpeed, ForceMode.Impulse);
                isOntheGround = false;
                MaxNumberofJumps--;
            }
        }

        //shows number of jumps left
        showJump();

    }

    void showJump()
    {
        jumps.text = MaxNumberofJumps.ToString("0");
    }

    private void OnCollisionEnter(Collision collision)  //for JUMPS IMMA USE COLLISION DETECTOR NOW. THIS IS SO MUCH FUCKING BETTER!!!
    {
        if(collision.collider.tag=="Ground")
        {
            isOntheGround = true;
        }
    }
}
