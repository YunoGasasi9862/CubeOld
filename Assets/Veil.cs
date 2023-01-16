using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veil : MonoBehaviour
{
    [SerializeField] Transform[] Points;
    [SerializeField] GameObject healthpotion;
    void Start()
    {
        int State = Random.Range(0, 2);

        switch(State)
        {
            case 0:
              break;

            case 1:
                int GeneratePos = Random.Range(0, Points.Length);
                for(int i=0; i<Points.Length; i++)
                {
                    if(GeneratePos==i)
                    {
                        Instantiate(healthpotion, Points[GeneratePos].position, Quaternion.identity);
                    }
                }
                break;
        }

    }

   
}
