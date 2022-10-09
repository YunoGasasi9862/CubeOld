using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody rb;
    float speed = 50f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {


        //check tomorrow how to move it without using Vector3.movetowards
          transform.position= Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);

        //using the DotProduct method, and rotating it on that Axis only

        float DotProduct = Vector3.Dot(transform.position, Player.transform.position);

        DotProduct = DotProduct / (transform.position.magnitude * Player.transform.position.magnitude);


        //remember the formula -> cosOfangle= (Vector1* Vector2)/(their magnitudes) Trignometry!
        float angleinRadians = Mathf.Acos(DotProduct);


        //if need in degrees
        float angleinDegrees = (angleinRadians) * (180 / Mathf.PI);

        transform.rotation = Quaternion.AngleAxis(angleinDegrees, Vector3.right);
         
        



      /**
            //for rotating in that direction

        Vector3 RotateDirection = Player.transform.position - transform.position;

        //fromToRotation is must (because it assigns the rotation => Rotate the X axis toward the target 
        Quaternion rotation = Quaternion.FromToRotation(transform.right, RotateDirection);


        //Lerp simply interpolates the rotation => current transform.rotation to rotation which we calculated before in this amount of time
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime);

        **/
    }
}
