using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFire : MonoBehaviour
{
    [SerializeField] LayerMask Ground;
    private RaycastHit hit;
    private float count = 0f;

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(transform.position, -transform.up, out hit, 1f, Ground);
        Debug.DrawRay(transform.position, -transform.up * 1f, Color.magenta);

        if(hit.collider!=null && hit.collider.CompareTag("Ground"))
        {
            count += Time.deltaTime;

            if(count>=1f)
            {
                Destroy(gameObject);
                count = 0;
            }
        }
    }
}
