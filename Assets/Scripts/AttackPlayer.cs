using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject Laser;
    private bool isInstantiated = false;
    private GameObject laserFire;
    [SerializeField] Rigidbody laserFireRb;
    void Update()
    {
        float Distance = Vector3.Distance(transform.position, player.transform.position);
        if (Distance <=200f && !isInstantiated)
        {
            laserFire = Instantiate(Laser, transform.position, Quaternion.identity);
  
            isInstantiated = true;
        }

        if(laserFireRb.velocity.magnitude <=.1f)
        {
            Destroy(laserFire, 3f);
        }
    }
}
