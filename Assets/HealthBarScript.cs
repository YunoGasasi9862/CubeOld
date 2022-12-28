using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    [SerializeField] Slider slide;
    float value;
    void Start()
    {
        slide = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(slide);
        if(slide!=null)
        {
            value += Time.deltaTime;
            slide.value -= value;
        }
       
    }
}
