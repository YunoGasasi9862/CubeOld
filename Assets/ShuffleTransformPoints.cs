using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleTransformPoints : MonoBehaviour
{
    public GameObject spawnPoint;
    GameObject shuffle;
    public int SpawnPoints = 3;
    private float minDistance= 6f;
    private float MaxDistance = 10f;
    private float minX = -6f, maxX = 6f;
    public Vector3 pos;
    ObstalceGenerator track;
    private void Start()
    {
        StartCoroutine(ShufflePoints());
        track = GameObject.FindObjectOfType<ObstalceGenerator>();
    }
    IEnumerator ShufflePoints()
    {

        //3 points only
   
          pos = transform.position;
          for(int i=0; i<SpawnPoints; i++) { 
            pos.x = Random.Range(minX, maxX);
            pos.z += Random.Range(minDistance, MaxDistance);
            shuffle = Instantiate(spawnPoint, pos, Quaternion.identity); //this seems to work now, WTF??
            track.position = pos; //assigning the position for every new object

        }

        yield return null;
    }


}