using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    public Transform orientation;
    private float xRotation;
    private float yRotation;

    public PlayerData playerData;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 look = context.ReadValue<Vector2>();
        yRotation += look.x * playerData.SensY * Time.deltaTime;
        xRotation -= look.y * playerData.SensX * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
