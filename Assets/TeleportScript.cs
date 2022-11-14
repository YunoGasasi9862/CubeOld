using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    private SkinnedMeshRenderer smr;
    [SerializeField] GameObject Fire;
    
    void Start()
    {
        smr = transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {

            //push the player in the Air

            transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 20f * Time.deltaTime, ForceMode.Impulse);

            //Disable it
            smr.enabled = false;


            //Move the camera 10F


            //bring back the player Again

        }
    }
}
