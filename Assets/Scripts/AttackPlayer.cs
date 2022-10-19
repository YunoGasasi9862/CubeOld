using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;
    private bool isInstantiated = false;
    private GameObject laserFire;
    [SerializeField] GameObject[] Lasers;
    public GameObject[] instantiatedLasers;

 
    void Update()
    {
        float Distance = Vector3.Distance(transform.position, player.transform.position);
        if (Distance <= 400f && !isInstantiated)
        {
            for(int i=0; i< Lasers.Length; i++)
            {
                _ = Timer(); //THIS IS WORKING YEEHAW!
                laserFire = Instantiate(Lasers[i], transform.position, Quaternion.identity);
                isInstantiated = true;


            }

            instantiatedLasers = GameObject.FindGameObjectsWithTag("Laser");

          


        }

        foreach(GameObject x in instantiatedLasers)
        {
            if(x!=null)
            {
                if (x.GetComponent<Rigidbody>().velocity.magnitude <= .1f)
                {
                    Destroy(x, 3f);
                }
            }
         
        }

           
     

        

    }





     async Task Timer()  //OMG THIS IS WORKING THEN
    {
        await Task.Delay(3000);
        //async mode allows you to use await
        //await + Task.Delay() doesnt freeze the screen!
    }
}
