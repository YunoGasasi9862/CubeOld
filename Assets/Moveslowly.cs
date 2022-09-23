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
    [SerializeField] GameObject planet;
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

        newLocation.y = 92.0f;
        newLocation.z = player.transform.position.z + 1000f;
    }
    void Update()
    {
        rb.velocity = new Vector3(0, 0, speed);
        transform.Rotate(0,0, 180 * Time.deltaTime);

        CheckForSpace();

        if(destroy==true)
        {
            Instantiate(planet, newLocation, Quaternion.identity);
            destroy = false;
        }
    }

    void CheckForSpace()
    {
        //if(Mathf.Abs(Vector3.Distance(transform.position, player.transform.position))<=120f)
        if (transform.position.z <= player.transform.position.z) //wtf THIS IS WORKING? but not the
            //but not the DistancE? FUCK YOU !!
        {
            Destroy(gameObject);
            destroy = true;
        }
    }
}
