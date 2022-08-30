using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidewithBoundary : MonoBehaviour
{
    [SerializeField] LevelGenerator generator;
    float DistanceZ = 22;

    private void Awake()
    {
        generator = FindObjectOfType<LevelGenerator>().GetComponent <LevelGenerator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(transform.parent.gameObject, 2f);

            //after that platform is destroyed
            Instantiate(generator.plat, generator.pos, generator.plat.transform.rotation);
            generator.pos.z += DistanceZ;

        }
    }
}
