using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaChange : MonoBehaviour
{
    [SerializeField] Material myMaterial;
    void Start()
    {
        Color color = myMaterial.color;
        color.a = 0f;
        myMaterial.color = color;
    }

   
}
