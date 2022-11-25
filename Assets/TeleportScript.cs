using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TeleportScript : MonoBehaviour
{
    private SkinnedMeshRenderer smr;
    [SerializeField] GameObject Fire;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask teleportScreen;
    private Rigidbody rb;
    private CapsuleCollider col;
    private float timing = 0f;
    private bool launchtiming = true;
    private bool thrustup = false;
    private GameObject _fire;
    private Vector3 posBelow;
    private Vector3 rotation;
    private bool teleport = false;
    public RaycastHit hit;

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
        if (RayCast() && teleport)
        {

            //push the player in the Air
            launchtiming = false;
            thrustup = true;
            posBelow.y = transform.position.y - .3f;
            Fire.transform.rotation = Quaternion.Euler(rotation);
            _fire = Instantiate(Fire, posBelow, Fire.transform.rotation);
            _fire.transform.parent = transform;
            teleport = false;



        }


        if (launchtiming && rb.isKinematic)
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
        if (rb.velocity.y < -1 && !launchtiming)  //all i have to do is put it in the fixed update;
        {
            rb.isKinematic = true;
            launchtiming = true;
           
        }

        if(thrustup)
        {
            rb.AddForce(transform.up * 600f * Time.deltaTime, ForceMode.Impulse);  //in fixedupdate :)
            thrustup = false;
        }

        Debug.DrawRay(transform.position, transform.forward * 1f, Color.black);
        Physics.Raycast(transform.position, transform.forward, out hit, 1f, teleportScreen);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f, teleportScreen)) //output in hit
        {
            if (hit.collider.isTrigger) //check if the collider is a hit
            {
                teleport = true;
                hit.collider.GetComponent<BoxCollider>().enabled = false;
               


            }

        }

    }

            public bool RayCast()
        {
            Debug.DrawRay(transform.position, -transform.up * 1f, Color.red);
            return Physics.Raycast(transform.position, -transform.up, 1f, ground);
        }

  
  
        
    
}
