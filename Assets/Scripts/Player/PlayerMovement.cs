using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public string FloorTag { get; private set; }
    public bool isMoving { get; private set; }



    public Vector3 MoveDirection { get; private set; }
    public Vector3 MoveDirectionUI { get; private set; }
    public Rigidbody Rb { get; private set; }



    private void Awake()
    {
        SoundManager.Initialize();
        Rb = GetComponent<Rigidbody>();
        Rb.freezeRotation = true;

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

        Ray ray = new Ray(transform.position, Vector3.down * 2);
        //ver el ray en la escena
        Debug.DrawRay(ray.origin, ray.direction * 2, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            FloorTag = hit.collider.tag;
            Debug.Log("Estás pisando" + FloorTag);
        }
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
            isMoving = true;

            Debug.Log("se mueve");

            //Edgar
            // verifica el tag del piso y si es isMoving = true , entonces reproduce el sonido de pasos
            /*
            if (FloorTag == "Concreto" && isMoving)
            {
                SoundManager.PlaySound(SoundManager.Sound.PlayerWalkConcrete);
            }
            else if (FloorTag == "Muelle" && isMoving)
            {
                SoundManager.PlaySound(SoundManager.Sound.PlayerWalkWood);
            }
            */

        }
        else if (context.canceled)
        {
            HorizontalInput = 0;
            VerticalInput = 0;
            MoveDirection = Vector3.zero;
            isMoving = false;
            Debug.Log("se para");
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
