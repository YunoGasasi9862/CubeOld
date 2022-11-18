using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TeleportScript : MonoBehaviour
{
    private SkinnedMeshRenderer smr;
    [SerializeField] GameObject Fire;
    [SerializeField] LayerMask ground;
    private Rigidbody rb;
    private CapsuleCollider col;
    private float timing = 0f;
    private bool launchtiming = true;
    private bool thrustup = false;
    private GameObject _fire;
    private Vector3 posBelow;
    private Vector3 rotation;


    void Start()
    {
        smr = transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
        col= GetComponent<CapsuleCollider>();
        rb= GetComponent<Rigidbody>();
        rotation = new Vector3(-90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        posBelow = transform.position;

        if (RayCast() && Input.GetKeyDown(KeyCode.R))
        {

            //push the player in the Air
            launchtiming = false;
            thrustup = true;
            posBelow.y = transform.position.y - .3f;
            Fire.transform.rotation = Quaternion.Euler(rotation);
            _fire = Instantiate(Fire, posBelow, Fire.transform.rotation);
            _fire.transform.parent = transform;
            //Disable it
           

        }
        //Move the camera 10F

        if(launchtiming && rb.isKinematic)
        {
            smr.enabled = false;
            timing += Time.deltaTime;
            transform.position += transform.forward * 90f * Time.deltaTime; //teleporting
        
        }

        //bring back the player Again

        if(timing>.2f && launchtiming)
        {
            rb.isKinematic = false;

            timing = 0f;
            Destroy(_fire, 1f);
        }

        if(!rb.isKinematic)
        {
            smr.enabled = true;

        }

    }

    private void FixedUpdate()
    {
        if (rb.velocity.y <= -0.01 && !launchtiming)  //all i have to do is put it in the fixed update;
        {
            rb.isKinematic = true;
            launchtiming = true;
        }

        if(thrustup)
        {
            rb.AddForce(transform.up * 500f * Time.deltaTime, ForceMode.Impulse);  //in fixedupdate :)
            thrustup = false;
        }
       
     
    }

    public bool RayCast()
    {
        Debug.DrawRay(transform.position, -transform.up * 1f, Color.red);
        return Physics.Raycast(transform.position, -transform.up, 1f, ground);
    }
}
