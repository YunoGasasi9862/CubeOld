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
    private bool allowCoRoutine=true;
 
    void Update()
    {
        float Distance = Vector3.Distance(transform.position, player.transform.position);
        if (Distance <= 400f && !isInstantiated)
        {
           
            if(allowCoRoutine)
            {
                StartCoroutine(SpawnLasers());  //better method!
                allowCoRoutine = false;
            }

        }

        foreach (GameObject x in instantiatedLasers)
        {
            if (x != null)
            {
                if (x.GetComponent<Rigidbody>().velocity.magnitude <= .1f)
                {
                    Destroy(x, 3f);
                }
            }

        }

    }

    IEnumerator SpawnLasers()
    {
        for (int i = 0; i < Lasers.Length; i++)
        {
            //THIS IS WORKING YEEHAW!
            yield return new WaitForSeconds(.5f);  //this method is perfect and better!!
            laserFire = Instantiate(Lasers[i], transform.position, Quaternion.identity);
          

        }

        instantiatedLasers = GameObject.FindGameObjectsWithTag("Laser");
        isInstantiated = true;
    }
 
}
