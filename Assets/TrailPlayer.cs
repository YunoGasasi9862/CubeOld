using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailPlayer : MonoBehaviour
{

    private GameObject Player;
    private Vector3 TempPos;
    private Vector3 TempPos2;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        TempPos = Player.transform.position;
    }
    void Update()
    {
      
        if (Player!=null && Vector2.Distance(transform.position, Player.transform.position)<=2f)
         {
       
                transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z-2f);
              
        }
        

    }



}
