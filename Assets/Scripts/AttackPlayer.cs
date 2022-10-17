using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject Laser;
    private bool isInstantiated = false;
    private GameObject laserFire;
    [SerializeField] int NumberofLasers;
    [SerializeField] Rigidbody laserFireRb;
     void Update()
    {
        float Distance = Vector3.Distance(transform.position, player.transform.position);
        if (Distance <= 400f && !isInstantiated)
        {
            while (NumberofLasers > 0)
            {
                _ = Timer();  //THIS IS WORKING YEEHAW!
                laserFire = Instantiate(Laser, transform.position, Quaternion.identity);
                NumberofLasers--;

            }
            isInstantiated = true;
               

        }

        if(laserFireRb.velocity.magnitude <=.1f)
        {
            Destroy(laserFire, 3f);
        }
    }

     async Task Timer()  //OMG THIS IS WORKING THEN
    {
        await Task.Delay(1400);
        //async mode allows you to use await
        //await + Task.Delay() doesnt freeze the screen!
    }
}
