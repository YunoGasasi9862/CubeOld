using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidewithBoundary : MonoBehaviour
{
    [SerializeField] LevelGenerator generator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(transform.parent.gameObject);

        }
    }
}
