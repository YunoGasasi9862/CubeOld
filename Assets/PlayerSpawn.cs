pusing System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject Astronaut;

    void Start()
    {
        cam.enabled = false;
        Instantiate(Astronaut, transform.position, Quaternion.identity);
    }


}
