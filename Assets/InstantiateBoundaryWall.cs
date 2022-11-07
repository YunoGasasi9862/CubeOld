using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBoundaryWall : MonoBehaviour
{

    private GameObject Player;
    [SerializeField] GameObject boundary;
    private Vector3 pos;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pos.y = transform.position.y + 7f;
            Instantiate(boundary, pos, boundary.transform.rotation);
            gameObject.SetActive(false);
        }
    }
   
}
