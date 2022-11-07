using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailPlayer : MonoBehaviour
{

    private GameObject Player;
    [SerializeField] float speed=20f;
    private Vector3 prev;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
      
        if (Vector3.Distance(transform.position, Player.transform.position)>10f)
         {

            transform.Translate(0,speed * Time.deltaTime,0); //because i have rotated it on the y-axis by 90 degrees, so the orientation has changed
            prev = transform.position;
        }
        else
        {
            transform.position = prev;

        }

        Debug.Log(Vector3.Distance(transform.position, Player.transform.position) >= 2f);


    }

}
