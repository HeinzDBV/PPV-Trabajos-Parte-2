using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private float duration;
    public Transform CameraPlayer;
    public Transform target;
    private bool ispaused = false;


    private void Awake() 
    {
        ispaused = false; 
    }

    private void Update() 
    {

    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed && ispaused == false)
        {
            print("UwU");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;

            EnterPauseMenu(target);
        }
        else if (context.performed && ispaused == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            ExitPauseMenu(target);
        }
    }
    public void EnterPauseMenu(Transform target)
    {
        ispaused = true;
        CameraPlayer.transform.DOLookAt(target.position, duration);
    }
    public void ExitPauseMenu(Transform target)
    {
        ispaused = false;
        CameraPlayer.transform.DOLookAt(new Vector3(0,0,0), duration);
    }
}
