using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardPlayer : MonoBehaviour
{
    private bool _CanMove;
    private Vector3 _Position;
    private Vector3 _NewPosition;
    public static bool SwapCamera = false;
    private float elapsedTime = 0f;

    
    private void Update()
    {
        if (_CanMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, _NewPosition, 3f * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            if(elapsedTime>=1.5f)
            {
                SwapCamera = true;
                elapsedTime = 0f;
                _CanMove = false;
            }
           

        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _Position = other.transform.position;
            _CanMove = true;
            _NewPosition.x = _Position.x;
            _NewPosition.y = _Position.y +1.5f;
            _NewPosition.z = _Position.z -4f;

        }
    }
}
