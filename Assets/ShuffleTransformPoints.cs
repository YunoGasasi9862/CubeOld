using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleTransformPoints : MonoBehaviour
{
    public GameObject spawnPoint;
    public int SpawnPoints = 3;
    private float minDistance= 6f;
    private float MaxDistance = 10f;
    private float minX = -6f, maxX = 6f;
    private void Start()
    {
        StartCoroutine(ShufflePoints());
    }
    IEnumerator ShufflePoints()
    {

        //3 points only
        Vector3 pos = transform.position;
       for(int i=0; i<SpawnPoints; i++) { 
            pos.x = Random.Range(minX, maxX);
            pos.z += Random.Range(minDistance, MaxDistance);
            GameObject shuffle = Instantiate(spawnPoint, pos, Quaternion.identity); //this seems to work now, WTF??

        }



        yield return null;
    }


}