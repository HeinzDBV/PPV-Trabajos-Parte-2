using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerData playerData;
    public Transform orientation;
    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }
    public bool IsSprinting { get; private set; }

    public Vector3 MoveDirection { get; private set; }
    public Rigidbody Rb { get; private set; }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.freezeRotation = true;

        HorizontalInput = 0;
        VerticalInput = 0;
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        MoveDirection = orientation.forward * VerticalInput + orientation.right * HorizontalInput;
        MoveDirection.Normalize();
        Rb.velocity = MoveDirection * (IsSprinting ? playerData.SprintSpeed : playerData.MoveSpeed);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>();
            HorizontalInput = input.x;
            VerticalInput = input.y;
            Debug.Log("se mueve");
            SoundManager.PlaySound(SoundManager.Sound.PlayerWalkWood);
        }
        else if (context.canceled)
        {
            HorizontalInput = 0;
            VerticalInput = 0;
            MoveDirection = Vector3.zero;
            Debug.Log("se para");
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsSprinting = true;
        }
        else if (context.canceled)
        {
            IsSprinting = false;
        }
    }
}
