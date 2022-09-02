using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] GameObject pickup;
    void Start()
    {
        int Possible = Random.Range(0, 3);
        if(Possible==2)
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
