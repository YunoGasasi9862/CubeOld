using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    int NumberofGround = 40;

    public ArrayList platforms;
   public int ground;
    float DistanceZ = 22;
    public GameObject plat;
    [SerializeField] float LastPosition;
    private void Start()
    {
        platforms = new ArrayList(NumberofGround);
        StartCoroutine(GenerateLevel());
    }

  
    IEnumerator GenerateLevel()
    {
        Vector3 pos=transform.position;
        for( ground=0; ground<NumberofGround; ground++)
        {
            platforms.Add(1);
            GameObject platform = Instantiate(plat, pos, Quaternion.identity);
            pos.z += DistanceZ;
            LastPosition = pos.z;
        }

        yield return null;

    }
}
