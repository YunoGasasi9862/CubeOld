using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NuzzleInstantiate : MonoBehaviour
{
    [SerializeField] int bulletCount = 3;
    [SerializeField] private GameObject bullet;
    public bool isTrue=false;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");   
    }

    private void Update()
    {
        if(isTrue)
        {
            StartCoroutine(Bullets());
            isTrue = false;
        }
    }
    IEnumerator Bullets()
    {

     for(int i=0; i<bulletCount; i++)
        {
            yield return new WaitForSeconds(.3f);
            GameObject bul = Instantiate(bullet, transform.position, Quaternion.identity);
            bul.transform.parent = Player.transform;
            Destroy(bul, 5f);
        }


    }
}
