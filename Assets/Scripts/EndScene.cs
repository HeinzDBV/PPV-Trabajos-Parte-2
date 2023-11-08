using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class EndScene : MonoBehaviour
{
    public GameObject DeadScreen;


    public void Restart()
    {
        
        Time.timeScale = 1f;
        DeadScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
