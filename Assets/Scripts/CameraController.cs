using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Vector2 CameraSensitivity = new Vector2(5, 5);
    private float pitch = 0;
    private float yaw = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pitch -= Input.GetAxis("Mouse Y") * CameraSensitivity.x * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * CameraSensitivity.x;
        // yaw += Input.GetAxis("Mouse X") * CameraSensitivity.y * Time.deltaTime;
        yaw += Input.GetAxis("Mouse X") * CameraSensitivity.y;

        // pitch = Mathf.Clamp(value, min, max);
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        Camera.main.transform.eulerAngles = new Vector3(pitch, yaw, 0);
    }
}
