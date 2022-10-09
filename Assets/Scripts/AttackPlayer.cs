using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject Laser;
    private bool isInstantiated = false;
 
    void Update()
    {
        float Distance = Vector3.Distance(transform.position, Laser.transform.position);
        if (Distance <=400f && !isInstantiated)
        {
            GameObject laserFire = Instantiate(Laser, transform.position, Quaternion.identity);
            isInstantiated = true;
        }

     

     

    }
}
