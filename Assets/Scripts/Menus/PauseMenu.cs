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
    public Transform Tablilla;
    public Transform target;
    [SerializeField] private PlayerInput playerInput;
    public static bool ispaused = false;
    public List<Vector3> position = new();
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject ExitConfirm;

    private void Awake() 
    {
        ispaused = false; 

        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        ExitConfirm.SetActive(false);
        
        //IF reconocer Mando para que seleccione automaticamente las opciones 
    }

    private void Update() 
    {
        if(PauseMenu.ispaused == false)
        {
            //Tablilla.position = CameraPlayer.position;
            //Tablilla.rotation *= CameraPlayer.rotation;
        }      
    }

    private void FixedUpdate() 
    {
        if(PauseMenu.ispaused == false)
        {
            
            if(position.Count < 2)
            {
                position.Add(CameraPlayer.position);
            }
            else
            {
                position.RemoveAt(0);
            }
        }
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed && ispaused == false)
        {
            print("UwU");
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            EnterPauseMenu(target);
            playerInput.SwitchCurrentActionMap("UI");
        }
        else if (context.performed && ispaused == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            ExitPauseMenu(target);
            playerInput.SwitchCurrentActionMap("Playing");
        }
    }
    public void EnterPauseMenu(Transform target)
    {
        ispaused = true;
        CameraPlayer.transform.DOLookAt(target.position, duration);
        pauseMenu.SetActive(true);
    }

    public void EnterOptions()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void QuitOptions()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void EnterExitPauseConfirmation()
    {
        pauseMenu.SetActive(false);
        ExitConfirm.SetActive(true);
    }
    public void QuitExitPauseConfirmation()
    {
        pauseMenu.SetActive(true);
        ExitConfirm.SetActive(false);
    }

    public void ExitPauseMenu(Transform target)
    {
        duration = 0.5f;
        Vector3 pos = CameraPlayer.position;
        pos = position[0];
        CameraPlayer.transform.DOLookAt(pos, duration);
        ispaused = false;
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        ExitConfirm.SetActive(false);
    }
}
