using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;
 
    void Update()
    {
        float Distance = Vector3.Distance(transform.position, player.transform.position);
        if (Distance <= 400f)
        {
            Debug.Log("Shoot");
        }

     

    }
}
