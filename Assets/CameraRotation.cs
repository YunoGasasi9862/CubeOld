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
        yRotation = Mathf.Clamp(yRotation, -90, 90); //THIS WORKED :)))

        transform.localRotation = Quaternion.Euler(yRotation, MouseY, 0);

        Cube.transform.Rotate(Vector3.up * MouseX); //Rotate MouseY on X axis, and MouseX on Y axis
                                                    //you have to Rotate the Cube
                                                    //WHY I ALWAYS FORGET THAT I HAVE TO MOVE PUT THE CUBES BODY HERE


    }
}
