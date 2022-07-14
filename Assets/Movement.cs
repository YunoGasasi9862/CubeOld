using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float MouseSensitivity = 100f;
    public float speed = 20f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");//for X movement  (THESE ARE WAY FUCKING BETTER) AXIS
        float Vertical = Input.GetAxis("Vertical");//for Z movement

        Horizontal = Horizontal* speed * Time.deltaTime;
        Vertical = Vertical * speed * Time.deltaTime;

        transform.Translate(Horizontal, 0, Vertical);  //initializing it with new Vector3 or you can simply use Horizontal, 0, Vertical too
    }
}
