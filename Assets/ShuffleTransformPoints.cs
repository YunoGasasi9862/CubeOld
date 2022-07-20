using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleTransformPoints : MonoBehaviour
{
    public GameObject spawnPoint;
    public int SpawnPoints = 3;
    private float MaxDistance = 0.3f;
    private float minX = -0.5f, maxX = 0.45f;
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
            pos.z += MaxDistance;
            GameObject shuffle = Instantiate(point, point.position, point.rotation).gameObject; //this seems to work now, WTF??


        }



        yield return null;
    }


}