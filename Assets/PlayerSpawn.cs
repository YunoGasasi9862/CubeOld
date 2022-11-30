using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject Astronaut;

    void Start()
    {
        cam = GameObject.FindWithTag("TemporaryCamera").GetComponent<Camera>();
        Invoke("InstantiatePlayer", 2f);
    }

    public void InstantiatePlayer()
    {
        //bring Player from above!!
        Instantiate(Astronaut, transform.position, Quaternion.identity);
        cam.enabled = false;

    }


}
