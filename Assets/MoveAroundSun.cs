using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundSun : MonoBehaviour
{

    float angle = 0;
    [SerializeField] bool XY;
    [SerializeField] bool XZ;
    [SerializeField] bool YZ;

    private void Start()
    {
        int Choose = Random.Range(0, 3);

        switch (Choose)
        {
            case 0:
                XY = true;
                break;
            case 1:
                XZ = true;
                break;
            case 2:
                YZ = true;
                break;
        }
    }
    void Update()
    {

      


         if(XY)
        {
            XtoY();
            XZ = false;
            YZ = false;
        }else if(XZ)
        {
            XtoZ();
            XY = false;
            YZ = false;
        }
        else if(YZ)
        {
            YtoZ();
            XY = false;
            XZ = false;
        }
        angle += .01f;

        if(angle>360)
        {
            angle = 0;
        }

       
    }

    void XtoZ()
    {
        transform.position = new Vector3(transform.parent.position.x + 100 * Mathf.Sin(angle*3), transform.position.y, transform.parent.position.z + 100 * Mathf.Cos(angle*3));

    }

    void XtoY()
    {
        transform.position = new Vector3(transform.parent.position.x + 100 * Mathf.Sin(angle*3), transform.parent.position.y + 100* Mathf.Cos(angle*3), transform.position.z);

    }
    void YtoZ()
    {
        transform.position = new Vector3(transform.position.x, transform.parent.position.y + 100* Mathf.Sin(angle *3), transform.parent.position.z + 100 * Mathf.Cos(angle *3));

    }




}
