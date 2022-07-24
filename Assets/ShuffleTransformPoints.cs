using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleTransformPoints : MonoBehaviour
{
    public GameObject spawnPoint;
     GameObject shuffle;
    private float minDistance= 6f;
    private float MaxDistance = 10f;
    private float minX = -6f, maxX = 6f;
    public Vector3 pos;

    public Transform[] spawnpoints;
  
    private void Start()
    {
        StartCoroutine(ShufflePoints());
    }
    IEnumerator ShufflePoints()
    {

        //3 points only
   
            pos = transform.position;
            pos.x = Random.Range(minX, maxX);
            pos.z += Random.Range(minDistance, MaxDistance);
            shuffle = Instantiate(spawnPoint, pos, Quaternion.identity); //this seems to work now, WTF??
                                                              //assigning the position for every new objec

        yield return null;
    }


}