using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NuzzleInstantiate : MonoBehaviour
{
    [SerializeField] int bulletCount = 10;
    [SerializeField] private GameObject bullet;
    public bool isTrue=false;
  
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
            yield return new WaitForSeconds(0.5f);

            GameObject bul = Instantiate(bullet, transform.position, Quaternion.identity);
            Destroy(bul, 5f);
        }


    }
}
