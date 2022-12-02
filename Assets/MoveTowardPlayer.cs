using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardPlayer : MonoBehaviour
{
    private Transform Player;
    private bool _CanMove;

    private void Update()
    {
        if (_CanMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, 3f * Time.deltaTime);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player = other.gameObject.transform;
            _CanMove = true;
        }
    }
}
