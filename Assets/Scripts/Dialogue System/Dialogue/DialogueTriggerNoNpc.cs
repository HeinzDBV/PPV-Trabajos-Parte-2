using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTriggerNoNpc : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField]private PlayerInput playerInput;
    private bool isPlaying;
    [SerializeField]private InputActionReference inputActionReference;

    private void Update()
    {
        if (isPlaying)
        {
            InputAction action = inputActionReference.action;
            action.Disable();
        }
        else
        {
            InputAction action = inputActionReference.action;
            action.Enable();
        }
    }

    public void StartDialogueModeRemote()
    {
        isPlaying = true;
        Cursor.lockState = CursorLockMode.Locked;
        playerInput.SwitchCurrentActionMap("Cinematics");
        DialogueManager.Instance.EnterDialogueMode(inkJSON);
    }

    public void ContinueDialogueRemote()
    {
        DialogueManager.Instance.ContinueStory();
        if(!DialogueManager.Instance.currentStory.canContinue)
        {
            isPlaying = false;
            playerInput.SwitchCurrentActionMap("Playing");
        }
    }
    public void ExitDialogueRemote()
    {
        isPlaying = false;
        StartCoroutine(DialogueManager.Instance.ExitDialogueMode());
        
    }

    public IEnumerator ReturnToPlay()
    {
        yield return new WaitForSeconds(0.2f);
        playerInput.SwitchCurrentActionMap("Playing");

    }
}
