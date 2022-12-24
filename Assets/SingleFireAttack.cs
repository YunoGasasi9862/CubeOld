using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFireAttack : MonoBehaviour
{
    [SerializeField] GameObject Fire;
    [SerializeField] Transform Mouth;
  

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Emit()
    {
        Instantiate(Fire, Mouth.transform.position, Quaternion.identity);
    }
}
