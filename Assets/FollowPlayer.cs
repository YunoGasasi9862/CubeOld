using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private Rigidbody rb;
    float speed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
       Vector3 followPlayer = Player.transform.position - transform.position; 

       rb.AddForce(followPlayer * speed* Time.deltaTime);

        Quaternion rotation = Quaternion.LookRotation(followPlayer);
        transform.rotation = rotation;

    }
}
