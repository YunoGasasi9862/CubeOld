using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFireAttack : MonoBehaviour
{
    [SerializeField] GameObject Fire;
    [SerializeField] Transform Mouth;
  

    public void Emit()
    {
        Instantiate(Fire, Mouth.transform.position, Quaternion.identity);
    }
}
