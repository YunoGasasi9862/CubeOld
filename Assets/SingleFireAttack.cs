using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFireAttack : MonoBehaviour
{
    [SerializeField] GameObject Fire;
    [SerializeField] Transform Mouth;
    [SerializeField] GameObject Player;



    private void Update()
    {
        if(Player==null)
        {
            Player = GameObject.FindWithTag("Player");
        }
    }
    public void Emit()
    {

        if(transform.position.z > Player.transform.position.z)
             Instantiate(Fire, Mouth.transform.position, Quaternion.identity);
    }
}
