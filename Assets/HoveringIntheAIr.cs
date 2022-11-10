using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveringIntheAIr : MonoBehaviour
{

    [SerializeField] Transform[] HoverPoints;
    private int Index;
    [SerializeField] float HoverSpeed = 30f;



    void Update()
    {
        if(Vector3.Distance(transform.position, HoverPoints[Index].transform.position) <.1f)
        {
         
            Index++;

            if(Index>=HoverPoints.Length)
            {
                Index = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, HoverPoints[Index].transform.position, HoverSpeed * Time.deltaTime);

    }

    
}
