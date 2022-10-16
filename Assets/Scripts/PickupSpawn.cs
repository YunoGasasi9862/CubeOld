using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] GameObject pickup;
    [SerializeField] int Possible;
    void Start()
    {
         Possible = Random.Range(0, 15);
        if(Possible==3 || Possible==7)
        {
            int index = Random.Range(0, points.Length);
            for (int i = 0; i < points.Length; i++)
            {
                if (i == index)
                {
                    points[i].gameObject.SetActive(true);
                    Instantiate(pickup, points[i].transform.position, Quaternion.identity);
                   
                }
                else
                {
                    points[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            return;
        }


    }

}
