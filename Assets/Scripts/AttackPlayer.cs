using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;
    private bool isInstantiated = false;
    private GameObject fireTemp;
    [SerializeField] GameObject[] FireObjects;
    public GameObject[] instantiatedFireObjects;
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

        foreach (GameObject x in instantiatedFireObjects)
        {
            if (x != null)
            {
                if (x.GetComponent<Rigidbody>().velocity.magnitude <= .1f)
                {
                    Destroy(x, 5f);
                }
            }

        }

    }

    IEnumerator SpawnLasers()
    {
        for (int i = 0; i < FireObjects.Length; i++)
        {
            //THIS IS WORKING YEEHAW!
            yield return new WaitForSeconds(.5f);  //this method is perfect and better!!
            fireTemp = Instantiate(FireObjects[i], transform.position, Quaternion.identity);
          

        }

        instantiatedFireObjects = GameObject.FindGameObjectsWithTag("Fire");
        isInstantiated = true;
    }
 
}
