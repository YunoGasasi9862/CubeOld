using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Moveslowly : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 2f;

    [SerializeField] GameObject player;

    private bool destroy = false;
    private Vector3 newLocation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        int posCheck = Random.Range(0, 2);
        if(posCheck==0)
        {
            newLocation.x= -62f;
        }else
        {
            newLocation.x = 62f;
        }

        newLocation.y = 81.7f;
    }
    void Update()
    {
        rb.velocity = new Vector3(0, 0, speed);
        CheckForSpace();

        if(destroy)
        {


            destroy = false;
        }
    }

    void CheckForSpace()
    {
        if(transform.position.z  <  player.transform.position.z)
        {
            Destroy(gameObject);
            destroy = true;
        }
    }
}
