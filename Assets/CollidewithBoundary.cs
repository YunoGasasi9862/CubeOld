using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidewithBoundary : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            if(transform.parent!=null)
            {
                Destroy(transform.parent.gameObject); //fix this

            }
        }
    }
}
