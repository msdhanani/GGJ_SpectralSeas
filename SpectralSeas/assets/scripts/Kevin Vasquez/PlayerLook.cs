using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {
    // Private Values

    private bool PlayerAlive = true;
    private float xAxisClamp = 0.0f;
    // Public Vallues

    public float LookSensitivity;
    public Transform PlayerBody;

    // Update is called once per frame
    void Update()
    {
        if (PlayerAlive)
        {
            RotateCam();
        }
    }

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void RotateCam()
    {
        float CameraX = Input.GetAxis("Mouse X");
        float CameraY = Input.GetAxis("Mouse Y");

        float RotateCameraX = CameraX * LookSensitivity;
        float RotateCameraY = CameraY * LookSensitivity;

        xAxisClamp += RotateCameraY;

        Vector3 CameraRotate = transform.rotation.eulerAngles;
        Vector3 PlayerRotate = PlayerBody.rotation.eulerAngles;

        CameraRotate.x -= RotateCameraY;
        CameraRotate.z = 0;
        PlayerRotate.y += RotateCameraX;

        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            CameraRotate.x = -90;
        }

        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            CameraRotate.x = 90;
        }

        transform.rotation = Quaternion.Euler(CameraRotate);
        PlayerBody.rotation = Quaternion.Euler(PlayerRotate);
    }
}
