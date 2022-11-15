using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBoundaryWall : MonoBehaviour
{

    [SerializeField] GameObject boundary;
    [SerializeField] GameObject boundary2;
    // Update is called once per frame
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Spawn", 1f);
            gameObject.SetActive(false);

        }
    }

    void Spawn()
    {
        Instantiate(boundary, transform.position, boundary.transform.rotation);
        Instantiate(boundary2, transform.position, boundary.transform.rotation);
    }
}
