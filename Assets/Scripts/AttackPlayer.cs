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

    public GameObject[] FireLists = new GameObject[3];
    public GameObject[] instantiatedFireObjects;

    [SerializeField] GameObject FireBreath;
    public float Again = 0;
    private Vector3 pos;

    private void Start()
    {
      
        for (int i=0; i<FireLists.Length; i++)
        {
            FireLists[i] = FireBreath;
           
        }

        instantiatedFireObjects= new GameObject[FireLists.Length];


    }

    void Update()
    {
       
        player = GameObject.FindWithTag("Player");

        if(player!=null)
        {
            float Distance = Vector3.Distance(transform.position, player.transform.position);
            if (Distance <= 10f && !isInstantiated)
            {
                pos = transform.position;

                if (allowCoRoutine)
                {
                    StartCoroutine(SpawnLasers());  //better method!
                    allowCoRoutine = false;
                }

            }
        }



        if(!IsEmpty())
        {
            for (int i = 0; i < instantiatedFireObjects.Length; i++)
            {
                if (instantiatedFireObjects[i] != null)
                {
                    if (instantiatedFireObjects[i].GetComponent<Rigidbody>().velocity.magnitude <= .1f)
                    {
                        Destroy(instantiatedFireObjects[i], 2f);
                    }
                }
            }
        }
   
   

        if(IsEmpty())
        {
            Again += Time.deltaTime;
        }

        if(IsEmpty() && Again>=10f)
        {
            isInstantiated = false;
            allowCoRoutine = true;
            Again = 0;
        }

    }

    IEnumerator SpawnLasers()
    {
      
        for (int i = 0; i < FireLists.Length; i++)
        {
            //THIS IS WORKING YEEHAW!
            yield return new WaitForSeconds(2f);  //this method is perfect and better!!
            fireTemp = Instantiate(FireLists[i], transform.position, Quaternion.identity);
            instantiatedFireObjects[i] = fireTemp;

        }

        isInstantiated = true;
    }

    public bool IsEmpty()
    {
        int count = 0;
        for(int i=0; i<instantiatedFireObjects.Length; i++)
        {
            if(instantiatedFireObjects[i]==null)
            {
                count++;
            }
        }

        if(count==instantiatedFireObjects.Length)
        {
            return true;
        }

        return false;
    }


 
}
