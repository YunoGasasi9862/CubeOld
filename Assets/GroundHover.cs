musing System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHover : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform[] HoverPoints=new Transform[2];  //this initiliazes it to the size of 2
    private int Index=0;
    [SerializeField] float HoverSpeed = 30f;

    private void Start()
    {
       
        HoverPoints[0] = transform.parent.GetChild(1);  //sets the child
        HoverPoints[1] = transform.parent.GetChild(2);

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, HoverPoints[Index].transform.position) < .1f)
        {

            Index++;

            if (Index >= HoverPoints.Length)
            {
                Index = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, HoverPoints[Index].transform.position, HoverSpeed * Time.deltaTime);
    }
}
