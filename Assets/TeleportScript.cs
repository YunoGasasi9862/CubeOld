using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    private SkinnedMeshRenderer smr;
    [SerializeField] GameObject Fire;
    [SerializeField] LayerMask ground;
    private Rigidbody rb;
    private CapsuleCollider col;
    
    void Start()
    {
        smr = transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
        col= GetComponent<CapsuleCollider>();
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(RayCast() && Input.GetKeyDown(KeyCode.R))
        {

            //push the player in the Air

             rb.AddForce(transform.up * 400f * Time.deltaTime, ForceMode.Impulse);
             rb.useGravity = false;
            //Disable it
             smr.enabled = false;


            if(rb.velocity.magnitude <.1f)
            {
                rb.velocity = new Vector3(0, 0, 0);

            }

            if(rb.velocity.magnitude==0f)
            {
                rb.AddForce(transform.forward * 1000f * Time.deltaTime, ForceMode.Impulse);

            }




            //Move the camera 10F


            //bring back the player Again




        }

      
    }

    public bool RayCast()
    {
        Debug.DrawRay(transform.position, -transform.up * 1f, Color.red);
        return Physics.Raycast(transform.position, -transform.up, 1f, ground);
    }
}
