
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


        XRotation -= MouseY;

        XRotation = Mathf.Clamp(XRotation, -45, 45);

        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);  //rotattion of the parent: camera's parent is the cube

        Cube.transform.Rotate(Vector3.up * MouseX);


        //the is similar to transform.Rotate (0,0,4);

    }
}
