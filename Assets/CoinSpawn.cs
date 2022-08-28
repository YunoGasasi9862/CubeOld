using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{

    public Transform[] coinSpawn;
    public GameObject coin;
    void Start()
    {

        int Index = Random.Range(0, coinSpawn.Length);
        for(int i=0; i<coinSpawn.Length; i++)
        {
            if(i==Index)
            {
                coinSpawn[i].gameObject.SetActive(true);
               GameObject co= Instantiate(coin, coinSpawn[i].transform.position, Quaternion.identity);
                co.transform.parent = gameObject.transform;
            }
            else
            {
                coinSpawn[i].gameObject.SetActive(false);

            }
        }


    }


}
