using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleTransformPoints : MonoBehaviour
{
      public Transform[] spawnpoints;
    public GameObject obstacle;
    GameObject obst;

    private void Start()
    {
        int index = Random.Range(0, spawnpoints.Length);
        for (int i = 0; i < spawnpoints.Length; i++)
        {

            if (i == index)
            {
                spawnpoints[i].gameObject.SetActive(true);
                obst=Instantiate(obstacle, spawnpoints[i].transform.position, Quaternion.identity);
                obst.transform.parent = gameObject.transform;
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