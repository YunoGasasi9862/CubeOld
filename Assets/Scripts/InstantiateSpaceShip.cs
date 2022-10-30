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
    private bool invokePossible = true;
    private int minz = 1200;
    private int maxz = 1500;
    private int miny = 120;
    private int maxy = 150; 

    private void Start()
    {
        
         
        if (Player != null)
        {
            position = Player.transform.position;
            position.y = Player.transform.position.y + Random.Range(miny, maxy);
            position.z = Player.transform.position.z + Random.Range(minz, maxz);
            spaceship = Instantiate(SpaceShip, position, Quaternion.identity);
        }



    }

    void Update()
    {
        if(Player==null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        if(destroyed)
        {

            if(invokePossible)
            {
                Invoke("SpawnJet", 2.0f);
                invokePossible = false;  //yaya fixed it!
                //yaya fixed it XD
            }

        

        }
        else
        {
            if (spaceship.transform.position.z < Player.transform.position.z)
            {
                Destroy(spaceship, 5f);
                destroyed = true;
            }
        }

    }

     void SpawnJet() //using IEnumerator instead
    {


        if (Player != null)
        {
            position = Player.transform.position;
            position.y = Player.transform.position.y + Random.Range(miny, maxy);
            position.z = Player.transform.position.z + Random.Range(minz, maxz);
            spaceship = Instantiate(SpaceShip, position, Quaternion.identity);
            destroyed = false;
            invokePossible = true;

        }

    }




}
