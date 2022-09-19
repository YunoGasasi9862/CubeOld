
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

        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        XRotation -= mouseY;

        XRotation = Mathf.Clamp(XRotation, -45, 45);

        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);

        Cube.transform.Rotate(Vector3.up * mouseX);

        //the is similar to transform.Rotate (0,0,4);

    }
}
