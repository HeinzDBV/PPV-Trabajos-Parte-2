using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTriggerNoNpc : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField]private PlayerInput playerInput;

    public void StartDialogueModeRemote()
    {
        playerInput.SwitchCurrentActionMap("Cinematics");
        DialogueManager.Instance.EnterDialogueMode(inkJSON);
    }

    public void ContinueDialogueRemote()
    {
        DialogueManager.Instance.ContinueStory();
        if(!DialogueManager.Instance.currentStory.canContinue)
        {
            playerInput.SwitchCurrentActionMap("Playing");
        }
    }
    public void ExitDialogueRemote()
    {
        StartCoroutine(DialogueManager.Instance.ExitDialogueMode());
        playerInput.SwitchCurrentActionMap("Playing");
    }
}
