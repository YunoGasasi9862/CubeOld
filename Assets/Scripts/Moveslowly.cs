using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Moveslowly : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed ;
    [SerializeField] Renderer PlanetColor;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlanetColor = GetComponent<Renderer>();
        speed = Random.Range(-80, -70);
        float R = Random.Range(-10f, 10f);
        float G = Random.Range(-30f, 30f);
        float B = Random.Range(-5f, 50f);

        PlanetColor.material.SetColor("_EmissionColor", new Color(R, G, B)); //"_Color is the shader property name"
     
        //because the material 
        //Its _EmissiveColor for emission
    }
    void Update()
    {
        rb.velocity = new Vector3(0, 0, speed);

    }

  
}
