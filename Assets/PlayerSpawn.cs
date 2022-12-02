using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject Astronaut;
    private Vector3 spawnPoint;
    [SerializeField] LayerMask Player;
    public RaycastHit hit;
    private bool disableTemp = false;
    void Start()
    {
        cam = GameObject.FindWithTag("TemporaryCamera").GetComponent<Camera>();
        Invoke("InstantiatePlayer", 2f);
    }

 
    public void InstantiatePlayer()
    {
        //bring Player from above!!
        spawnPoint = transform.position;
        spawnPoint.y = transform.position.y + 10f; //the height from which the player drops
        Instantiate(Astronaut, spawnPoint, Quaternion.identity);

    }
    private void Update()
    {
        RayCast();
        if(disableTemp)
        {
            //cam.enabled = false;
        }

    }

 
    public void RayCast()
    {
      
        Physics.Raycast(transform.position, transform.up, out hit, 1f, Player);

        Debug.DrawRay(transform.position, transform.up * 1f, Color.red);

       if(hit.collider!=null)
        {
            hit.collider.gameObject.transform.GetChild(2).transform.GetChild(0).GetComponent<Camera>().enabled = true;
            //disableTemp = true;
        }

    }


}
