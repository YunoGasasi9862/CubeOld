using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonGenerate : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject DROG;
    private Vector3 position;
    private GameObject dragon;
    private bool invokePossible = true;
    private int minz = 1200;
    private int maxz = 1500;

    

    void Update()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        if (Player != null && invokePossible)
        {
            Invoke("SpawnJet", 2.0f);
            invokePossible = false;

        }


    }

    void SpawnJet() //using IEnumerator instead
    {


            position = Player.transform.position;
              position.y = Player.transform.position.y + 20;
            position.z = Player.transform.position.z + Random.Range(minz, maxz);
            dragon = Instantiate(DROG, position, DROG.transform.rotation);


    }
}
