using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DecisionFilter : MonoBehaviour
{
    [SerializeField] private string Good;
    [SerializeField] private string Bad;
    public void MakeitBe()
    {
        if(DialogueManager.decision == true)
        {
            SceneManager.LoadScene(Good);
        }
        else if(DialogueManager.decision == false)
        {
            SceneManager.LoadScene(Bad);
        }

    }

}
