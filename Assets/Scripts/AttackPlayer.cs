using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject Laser;
 
    void Update()
    {
        float Distance = Vector3.Distance(transform.position, player.transform.position);
        if (Distance <=400f)
        {
            GameObject laserFire = Instantiate(Laser, transform.position, Quaternion.identity);

        }

     

     

    }
}
