using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateStartPortal : MonoBehaviour
{
    [SerializeField] GameObject _StartPortal;
    private GameObject _SP;
    void Start()
    {
       
        Invoke("_InstantiateSPortal", .5f);
    }

   
    void _InstantiateSPortal()
    {
 
       _SP= Instantiate(_StartPortal, transform.position, _StartPortal.transform.rotation);
        _SP.transform.parent = transform;
        
       
    }
}
