using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckforPickup : MonoBehaviour
{
    [SerializeField] NuzzleInstantiate nuzzle;

    private void Start()
    {
        nuzzle = GetComponent<NuzzleInstantiate>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            //nuzzle.
        }
    }
}
