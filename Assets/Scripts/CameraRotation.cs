
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float MouseSensitivity = 200f;
    public GameObject Cube;
    float XRotation;
    private float minRotate=-45;
        private float MaxRotate=45;
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

        XRotation = Mathf.Clamp(XRotation, minRotate, MaxRotate);

        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);

        Cube.transform.Rotate(MouseX * Vector3.up);




        //the is similar to transform.Rotate (0,0,4);

    }
}
