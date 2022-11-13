using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckforPickup : MonoBehaviour
{
    [SerializeField] NuzzleInstantiate nuzzle;
    [SerializeField] GameObject particleAnim;

    private void Start()
    {
        nuzzle = GetComponent<NuzzleInstantiate>();
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            nuzzle.isTrue = true;
            Instantiate(particleAnim, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);

        }
    }
 
}
