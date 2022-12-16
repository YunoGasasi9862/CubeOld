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
   
    private bool allowCoRoutine=true;

    public static GameObject[] FireLists = new GameObject[3];
    public static GameObject[] instantiatedFireObjects = new GameObject[FireLists.Length];
    [SerializeField] GameObject FireBreath;

    private void Start()
    {
        for(int i=0; i<FireLists.Length; i++)
        {
            FireLists[i] = FireBreath;
           
        }


    }

    void Update()
    {
        player = GameObject.FindWithTag("Player");

        if(player!=null)
        {
            float Distance = Vector3.Distance(transform.position, player.transform.position);
            if (Distance <= 10f && !isInstantiated)
            {

                if (allowCoRoutine)
                {
                    StartCoroutine(SpawnLasers());  //better method!
                    allowCoRoutine = false;
                }

            }
        }

   
        for(int i=0; i<instantiatedFireObjects.Length; i++)
        {
            if (instantiatedFireObjects[i]!=null)
            {
                if (instantiatedFireObjects[i].GetComponent<Rigidbody>().velocity.magnitude <= .1f)
                {
                    Destroy(instantiatedFireObjects[i], 2f);
                }
            }

           
        }

    

        if(instantiatedFireObjects.Length==0 && Time.deltaTime >=10f)
        {
            isInstantiated = false;
            allowCoRoutine = true;
        }

    }

    IEnumerator SpawnLasers()
    {
        for (int i = 0; i < FireLists.Length; i++)
        {
            //THIS IS WORKING YEEHAW!
            yield return new WaitForSeconds(1f);  //this method is perfect and better!!
            fireTemp = Instantiate(FireLists[i], transform.position, Quaternion.identity);
            instantiatedFireObjects[i] = fireTemp;

        }

        isInstantiated = true;
    }
 
}
