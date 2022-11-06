using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailPlayer : MonoBehaviour
{

    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if(Player!=null)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z - 2f);

        }
    }
}
