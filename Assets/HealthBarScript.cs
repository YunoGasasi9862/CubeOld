using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    [SerializeField] Slider slide;
    [SerializeField] Image Fill;
    [SerializeField] Gradient gradient;
    void Start()
    {
        slide = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(slide!=null)
        {

            slide.value = (float)Movement.HEALTH;
            Fill.color = gradient.Evaluate(slide.value/ 100f); //normalized value is a must, because value is between 0 and 100, and Evaluate takes between 0 and 1.
            //either divide by 100 or use normalzied value
        }
       
    }
}
