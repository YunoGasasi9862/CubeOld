using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePortals : MonoBehaviour
{
    [SerializeField] GameObject Portal;
    private int _NumOfPortals = 40;
    private float distanceBetweenPortals = 100f;
    private Vector3 Placement;
    private GameObject[] ExistingPortals;
    void Start()
    {
        Placement.y = 5f;
        Placement.z = distanceBetweenPortals;
        StartCoroutine(GeneratorPortals());
   
    }
     IEnumerator GeneratorPortals()
    {
        for(int i=0; i < _NumOfPortals; i++)
        {
            GameObject dummyP=Instantiate(Portal, Placement, Quaternion.identity);
            Placement.z += distanceBetweenPortals;
            ExistingPortals[i] = dummyP;
        }

        yield return null;

    }
}
