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
    private float timing = 0f;
    private bool launchtiming = false;
    
    void Start()
    {
        smr = transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
        col= GetComponent<CapsuleCollider>();
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RayCast() && Input.GetKeyDown(KeyCode.R))
        {

            //push the player in the Air
            launchtiming = false;

            rb.AddForce(transform.up * 400f * Time.deltaTime, ForceMode.Impulse);

            //Disable it
            // smr.enabled = false;




        }
        //Move the camera 10F
        Debug.Log(timing);

        if(launchtiming && rb.isKinematic)
        {
            timing += Time.deltaTime;
        }

        //bring back the player Again

        if(timing>.5f && launchtiming)
        {
            rb.isKinematic = false;
            timing = 0f;
        }



    }

    private void FixedUpdate()
    {
        if (rb.velocity.y <= -0.01 && !launchtiming)  //all i have to do is put it in the fixed update;
        {
            rb.isKinematic = true;
            launchtiming = true;
        }
     

    }

    public bool RayCast()
    {
        Debug.DrawRay(transform.position, -transform.up * 1f, Color.red);
        return Physics.Raycast(transform.position, -transform.up, 1f, ground);
    }
}
