using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody rb;
    [SerializeField]float speed = 50f;
    private Vector3 previousPosition;
        
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {


        //check tomorrow how to move it without using Vector3.movetowards
     
          if(Vector2.Distance(transform.position, Player.transform.position)>=30)
         {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            previousPosition = transform.position;

        }
        else
          {
            transform.position = Vector3.MoveTowards(previousPosition, Player.transform.position, speed * Time.deltaTime);


        }


        //using the DotProduct method, and rotating it on that Axis only

        float DotProduct = Vector3.Dot(transform.position, Player.transform.position);


        DotProduct = DotProduct / (transform.position.magnitude * Player.transform.position.magnitude);


        //remember the formula -> cosOfangle= (Vector1* Vector2)/(their magnitudes) Trignometry!
        float angleinRadians = Mathf.Acos(DotProduct);


        //if need in degrees
        float angleinDegrees = angleinRadians * (180 / Mathf.PI);

        float PreviousRotationAngle = angleinDegrees;

        transform.rotation = Quaternion.AngleAxis(PreviousRotationAngle, Vector3.right);

        
         

       
    }


}
