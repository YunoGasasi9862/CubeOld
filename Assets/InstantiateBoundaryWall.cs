using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBoundaryWall : MonoBehaviour
{

    private GameObject Player;
    [SerializeField] GameObject boundary;
    [SerializeField] GameObject boundary2;
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
            Invoke("Spawn", 1f);
        }
    }

    void Spawn()
    {
        pos.y = transform.position.y + 6f;
        Instantiate(boundary, pos, boundary.transform.rotation);
        Instantiate(boundary2, pos, boundary.transform.rotation);
        gameObject.SetActive(false);
    }
}
