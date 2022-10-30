using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject Player;
    [SerializeField]float speed = 50f;
    [SerializeField] GameManager manager;
    [SerializeField] AudioSource GameOverclip;

    private float DotProduct;
    private float angleinRadians;
        private float angleinDegrees;
    private Vector3 previousPosition;
    private float previousAngle;
  
   
        
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        manager = FindObjectOfType<GameManager>();
    }
    void Update()
    {


        if (Vector2.Distance(transform.position, Player.transform.position) >= 20)  //OMG IT WORKED! I FUCKING DID IT!!!  (IT FOLLOWS THE PLAYER UNTIL THE DISTANCE IS > 20)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);

            previousPosition = Player.transform.position;


            //check tomorrow how to move it without using Vector3.movetowards




            //using the DotProduct method, and rotating it on that Axis only
            DotProduct = Vector3.Dot(transform.position, Player.transform.position);
            DotProduct = DotProduct / (transform.position.magnitude * Player.transform.position.magnitude);
            //remember the formula -> cosOfangle= (Vector1* Vector2)/(their magnitudes) Trignometry!

            angleinDegrees = Mathf.Acos(DotProduct);

            //if need in degrees
            angleinDegrees = angleinRadians * 180 / (Mathf.PI);
            previousAngle = angleinDegrees;


            transform.rotation = Quaternion.AngleAxis(angleinDegrees, Vector3.right);//rotates the angle on a given axis: so here, it turns it on the X axis

        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, previousPosition, speed * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(previousAngle, Vector3.right);
        }


    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            GameOverclip.Play();
            manager.pause();
        }
    }


}
