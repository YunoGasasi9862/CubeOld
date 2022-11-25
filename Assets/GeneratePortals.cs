using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneratePortals : MonoBehaviour
{
    [SerializeField] GameObject Portal;
    private float distanceBetweenPortals = 100f;
    private Vector3 Placement;
    private GameObject dummyP;
    private GameObject Player;
    private TeleportScript TS;

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        TS = Player.GetComponent<TeleportScript>();
    }
    void Start()
    {
       
        Placement.y = 5f;
        Placement.z = distanceBetweenPortals;
        dummyP = Instantiate(Portal, Placement, Portal.transform.rotation);


    }

    private void Update()
    {
        
        if(TS!=null && TS.hit.collider.isTrigger)
        {
            Invoke("InstantiatePortal", 1f);
        }
    }


  

    private void InstantiatePortal()
    {
        Placement.z += distanceBetweenPortals;
        dummyP = Instantiate(Portal, Placement, Portal.transform.rotation);
    

    }

}
