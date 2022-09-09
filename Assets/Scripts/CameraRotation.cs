
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float MouseSensitivity = 200f;
    public GameObject Cube;
    float XRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;


        XRotation -= MouseY;  //x rotation (against y axis)
        

        XRotation = Mathf.Clamp(XRotation, -45, 45);

        transform.localRotation = Quaternion.Euler(XRotation, 0, 0); //the rotation of the camera in relative to its parent, that is the CUBE!!!

        Cube.transform.Rotate(Vector3.up * MouseX); //y axis against X axix


        //the is similar to transform.Rotate (0,0,4);

    }
}
