using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    private SkinnedMeshRenderer smr;
    
    void Start()
    {
        smr = transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            smr.enabled = false;
        }
    }
}
