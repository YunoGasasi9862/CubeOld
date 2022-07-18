using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    int NumberofGround = 40;
    float DistanceZ = 20;
    public GameObject plat;
    private void Start()
    {
        StartCoroutine(GenerateLevel());
    }
    IEnumerator GenerateLevel()
    {
        Vector3 pos=transform.position;
        for(int ground=0; ground<NumberofGround; ground++)
        {
            GameObject platform = Instantiate(plat, pos, Quaternion.identity);
            pos.z += DistanceZ;
        }
       
        yield return null;

    }
}
