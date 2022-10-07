using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBackGround : MonoBehaviour
{
    [SerializeField] GameObject Audio;
    void Start()
    {
        Instantiate(Audio, transform.position, Quaternion.identity);
    }

 
}
