using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    int NumberofGround = 40;

   public int ground=0;
    float DistanceZ = 22;
    public GameObject plat;
    public GameObject platform;
    private void Start()
    {
        StartCoroutine(GenerateLevel());
    }


    IEnumerator GenerateLevel()
    {
        Vector3 pos=transform.position;
        for( ground=0; ground<NumberofGround; ground++)
        {


                platform = Instantiate(plat, pos, Quaternion.identity);
                pos.z += DistanceZ;



        }

        yield return null;

    }


}
