using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NuzzleInstantiate : MonoBehaviour
{
    [SerializeField] int bulletCount = 3;
    [SerializeField] private GameObject bullet;
    public bool isTrue=false;

    private Vector3 pos;

    private void Start()
    {
    
    }

    private void Update()
    {
        pos = transform.localPosition;
        if (isTrue)
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
            pos.z = transform.localPosition.z;
            GameObject bul = Instantiate(bullet, pos, Quaternion.identity);
            bul.transform.parent = transform;
            bul.GetComponent<Rigidbody>().detectCollisions = false;
            Destroy(bul, 5f);
        }


    }
}
