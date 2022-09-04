using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuzzleInstantiate : MonoBehaviour
{
    [SerializeField] int bulletCount = 10;
    [SerializeField] private GameObject bullet;

    private void Start()
    {
        StartCoroutine(Bullets());
    }

    IEnumerator Bullets()
    {

        for(int i=0; i<bulletCount; i++)
        {
           //I LOVE THIS ONE!
            yield return new WaitForSeconds(0.5f);
            GameObject bul= Instantiate(bullet, transform.position, Quaternion.identity);
            Destroy(bul, 5f);
        }


    }
}
