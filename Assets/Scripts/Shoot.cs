using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float shootingspeed = 50f;
    [SerializeField] GameObject Anim;
    Vector3 pos;

    [SerializeField] Camera cam;
   
    [SerializeField] AudioSource Explosionsound;
    Vector3 parentTransform;
    private float elapsedTime;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
     
        cam = Camera.main;

        parentTransform = transform.parent.forward; // yaya this worked
        //transform.parent.forward -> forward vector of the parent

        //what this line of code does? it simply assigns the transform.forward vector of the parent. 
        //In short allows you to addforce in the direction the parent's transform.forward is facing
  

    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > .2f)
        {
           // parentTransform = transform.forward;
            transform.SetParent(null);
        }

        rb.AddForce(parentTransform * shootingspeed);

        //the velocity in the Z-axis

        //transform.position+= transform.up * Mathf.Sin(Time.time * 20f) * .1f;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            AudioSource.PlayClipAtPoint(Explosionsound.clip, cam.transform.position);//THIS FIXED IT BUT HOW? Playing the audio at the bullet location?
            Destroy(collision.gameObject);
            GameObject animation = Instantiate(Anim, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);

           
        }
    }
}
