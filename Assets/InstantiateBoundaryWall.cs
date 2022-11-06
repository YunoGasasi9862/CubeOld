using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBoundaryWall : MonoBehaviour
{

    private GameObject Player;
    [SerializeField] GameObject boundary;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(boundary, transform.position, boundary.transform.rotation);
        }
    }
   
}
