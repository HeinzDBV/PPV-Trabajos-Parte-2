using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float MovementSpeed = 4;
    [SerializeField]
    private float RotationSpeed = 2f;

    private Vector3 direction = Vector3.zero;
    private Vector3 rotation = Vector3.zero;

    private CharacterController characterController;
    private Transform myCamera;

    public Animator animator;

    private void Awake() 
    {
        characterController = GetComponent<CharacterController>();   
        myCamera = transform.Find("Main Camera");
    }

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() 
    {
        // Movimiento
        characterController.Move(
            transform.forward * direction.normalized.z * Time.deltaTime * MovementSpeed
            + transform.right * direction.normalized.x * Time.deltaTime * MovementSpeed
        );

        // Rotacion Horizontal
        transform.Rotate(
            0f,
            rotation.y * RotationSpeed * Time.deltaTime,
            0f
        );

        // Rotacion vertical (camara)
        var rotationAngle = -rotation.x * RotationSpeed * Time.deltaTime;

        /*var desiredRotationQuat = Quaternion.Euler(transform.rotation.x + rotationAngle,
            0f,
            0f);
        

        Vector3 desiredRotation = desiredRotationQuat.eulerAngles;
        desiredRotation.x = desiredRotation.x > 180f 
            ? desiredRotation.x - 360f
            : desiredRotation.x ;

        desiredRotation.x = Mathf.Clamp(desiredRotation.x, -20f, 20f);
        /*myCamera.rotation = Quaternion.Euler(desiredRotation); */
        myCamera.Rotate(
            rotationAngle, //TODO: Clamp
            0f,
            0f
        );
    }

    // private void OnMove(InputValue value)
    // {
    //     var data = value.Get<Vector2>();
    //     direction = new Vector3(
    //         data.x,
    //         0f,
    //         data.y
    //     );
    // }

    public void OnMove(InputAction.CallbackContext value)
    {
        var data = value.ReadValue<Vector2>();
        direction = new Vector3(
            data.x,
            0f,
            data.y
        );
        
        if(value.performed)
        animator.SetBool("Walk", true);
        
        if(value.canceled)
        animator.SetBool("Walk", false);

        
    }

    // private void OnFire(InputValue value)
    // {
    //     if (value.isPressed)
    //     {
    //         myCamera.GetComponent<PlayerFire>().Fire();
    //     }
    // }

    public void OnFire(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            animator.SetTrigger("Shoot");
            myCamera.GetComponent<PlayerFire>().Fire();
        }


  
    }

    private void OnLook(InputValue value)
    {
        var data = value.Get<Vector2>();
        rotation = new Vector3(
            data.y,
            data.x, // rotacion horizontal (sobre eje Y)
            0f
        );
    }

    public void OnLook(InputAction.CallbackContext value)
    {
        var data = value.ReadValue<Vector2>();
        rotation = new Vector3(
            data.y,
            data.x, // rotacion horizontal (sobre eje Y)
            0f
        );
    }

    private void OnReload(InputValue value)
    {
        if (value.isPressed)
        {
            myCamera.GetComponent<PlayerFire>().Reload();
        }
    }

    public void OnReload(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            myCamera.GetComponent<PlayerFire>().Reload();
        }
    }

    private void OnSwitchGun(InputValue value)
    {
        if (value.isPressed)
        {
            myCamera.GetComponent<PlayerFire>().SwitchGun();
        }
    }

    public void OnSwitchGun(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            myCamera.GetComponent<PlayerFire>().SwitchGun();
        }
    }

    private void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            GetComponentInChildren<PlayerInteractArea>().Interact();
        }
    }

    public void OnInteract(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            GetComponentInChildren<PlayerInteractArea>().Interact();
            Debug.Log("Interact");
        }
    }

    private void OnUnequip(InputValue value)
    {
        if (value.isPressed)
        {
            GetComponentInChildren<PlayerFire>().DropGun();
        }
    }

    public void OnUnequip(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            GetComponentInChildren<PlayerFire>().DropGun();
        }
    }

    public void OnRun(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            MovementSpeed = 8;
        }
        else if (value.canceled)
        {
            MovementSpeed = 4;
        }
    }
}
