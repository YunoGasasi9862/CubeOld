using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSpaceShip : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject SpaceShip;
    private Vector3 position;
    private GameObject spaceship;
    private bool destroyed=false;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            position = Player.transform.position;
            position.y = Player.transform.position.y + 100f;
            position.z = Player.transform.position.z + 1000f;
            spaceship = Instantiate(SpaceShip, position, Quaternion.identity);
        }



    }

    void Update()
    {
        if(destroyed)
        {
 
           Invoke("SpawnJet", 2.0f);


        }
        if (spaceship!=null && spaceship.transform.position.z < Player.transform.position.z)
         {
                Destroy(spaceship, 5f);
                destroyed = true;
          }
        

    }

     void SpawnJet() //using IEnumerator instead
    {

        if (Player != null)
        {
            position = Player.transform.position;
            position.y = Player.transform.position.y + 100f;
            position.z = Player.transform.position.z + 1000f;
        }
        spaceship = Instantiate(SpaceShip, position, Quaternion.identity);
        destroyed = false;

    }




}
