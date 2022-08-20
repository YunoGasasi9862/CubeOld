using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float MouseSensitivity = 200f;
    public GameObject Cube;
    float yRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        yRotation -= MouseY;
        yRotation = Mathf.Clamp(yRotation, -45, 45);

        transform.localRotation = Quaternion.Euler(yRotation, 0, 0);

        Cube.transform.Rotate(Vector3.up * MouseX);
        //the is similar to transform.Rotate (0,0,4);

    }
}
