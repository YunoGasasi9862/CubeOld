using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Moveslowly : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 2f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = new Vector3(0, 0, speed);
        transform.Rotate(0,0, 180 * Time.deltaTime);

    }

  
}
