using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerData playerData;
    public Transform orientation;
    public Transform UI;
    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }
    public bool IsSprinting { get; private set; }
    public float CurrentSpeed;
    

    public Vector3 MoveDirection { get; private set; }
    public Vector3 MoveDirectionUI { get; private set; }
    public Rigidbody Rb { get; private set; }

    public bool IsHidden { get; set; }


    private void Awake()
    {
        SoundManager.Initialize();
        Rb = GetComponent<Rigidbody>();
        Rb.freezeRotation = true;
        IsHidden = false;

        HorizontalInput = 0;
        VerticalInput = 0;
    }

    void Start()
    {
        CurrentSpeed = playerData.MoveSpeed;
    }

    void Update()
    {
        ApplyGravity();
        
    }

    void FixedUpdate()
    {
        MoveDirection = orientation.forward * VerticalInput + orientation.right * HorizontalInput;
        MoveDirectionUI = UI.forward * VerticalInput + orientation.right * HorizontalInput;
        MoveDirectionUI.Normalize();
        MoveDirection.Normalize();

        Rb.velocity = MoveDirection * CurrentSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>();
            HorizontalInput = input.x;
            VerticalInput = input.y;
            //Debug.Log("se mueve");
            
            //Edgar
            // verifica tipo de piso y reproducir sonido si es madera o concreto
            if( Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1.5f) )
            {
                if (hit.collider.CompareTag("Muelle"))
                {
                    SoundManager.PlaySound(SoundManager.Sound.PlayerWalkWood);
                }
                else if (hit.collider.CompareTag("Concreto"))
                {
                    SoundManager.PlaySound(SoundManager.Sound.PlayerWalkConcrete);
                }
            }
            else
            {
                //Debug.Log("No hay piso");
            }
            

        }
        else if (context.canceled)
        {
            HorizontalInput = 0;
            VerticalInput = 0;
            MoveDirection = Vector3.zero;
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsSprinting = true;
            CurrentSpeed += playerData.SprintSpeed;
        }
        else if (context.canceled)
        {
            IsSprinting = false;
            CurrentSpeed -= playerData.SprintSpeed;
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CurrentSpeed = playerData.CrouchSpeed;
            transform.localScale = new Vector3(1, playerData.CrouchTransform, 1);
        }
        else if (context.canceled)
        {
            CurrentSpeed = playerData.MoveSpeed;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void ApplyGravity()
    {
        Rb.AddForce(Vector3.down * playerData.Gravity);
    }
}
