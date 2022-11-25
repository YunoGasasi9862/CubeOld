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
        prev.y = Player.transform.position.y + 10f;
        prev.z = -3f;
        transform.position = prev;
    }
    void Update()
    {
      
        if (Mathf.Abs(transform.position.z - Player.transform.position.z)>2f)
         {

            transform.Translate(0,speed * Time.deltaTime,0); //because i have rotated it on the y-axis by 90 degrees, so the orientation has changed
            prev = transform.position;
            prev.z = Player.transform.position.z - 2f;

        }
        else
        {
            transform.position = prev;

        }

      


    }

}
