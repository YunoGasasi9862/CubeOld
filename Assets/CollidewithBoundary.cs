using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidewithBoundary : MonoBehaviour
{
    [SerializeField] LevelGenerator generate;

    public int counter = 0;
    bool flag = false;
    private void Awake()
    {
        generate = GameObject.FindObjectOfType<LevelGenerator>().GetComponent<LevelGenerator>();

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {

            if(!flag)
            {
                generate.platforms[counter] = false;
                Debug.Log(generate.platforms[counter]);
                Destroy(transform.parent.gameObject); //fix this
                counter++;

            }
            flag = true;



        }
    }
}
