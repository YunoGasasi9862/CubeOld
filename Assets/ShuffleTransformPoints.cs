using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleTransformPoints : MonoBehaviour
{
      Transform spawnPoint;
      public Transform[] spawnpoints;
     public Vector3 pos;
    public GameObject obstacle;

    private void Start()
    {
        int index = Random.Range(0, spawnpoints.Length);
        spawnPoint = spawnpoints[index];
        for (int i = 0; i < spawnpoints.Length; i++)
        {

            if (i == index)
            {
                spawnpoints[index].gameObject.SetActive(true); //only that will be active
                Instantiate(obstacle, spawnpoints[index].transform.position, Quaternion.identity);
            }
            else
            {
                spawnpoints[i].gameObject.SetActive(false);  //the rest will be set t ofalse
            }
        }
        // Instantiate(spawnPoint, spawnPoint.transform.position, Quaternion.identity); //this seems to work now, WTF??
    }

    //assigning the position for every new objec


}