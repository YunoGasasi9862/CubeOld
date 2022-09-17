using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShuffleTransformPoints : MonoBehaviour
{
      public Transform[] spawnpoints;
    public GameObject obstacle;
    GameObject obst;

 
    private void Start()   //FIX THIS SCRIPT. Only ENABLE THE OBSTACLE, and SET IT PLACE TO THAT POINT!!
    {
        int index = Random.Range(0, spawnpoints.Length);
        for (int i = 0; i < spawnpoints.Length; i++)
        {

            if (i == index)
            {
                spawnpoints[i].gameObject.SetActive(true);
                obst = Instantiate(obstacle, spawnpoints[i].transform.position, Quaternion.identity);
                obst.transform.parent = gameObject.transform;

               
            }
            else
            {
                spawnpoints[i].gameObject.SetActive(false);  //the rest will be set t ofalse
            }
        }
       
    }


    //assigning the position for every new objec


}