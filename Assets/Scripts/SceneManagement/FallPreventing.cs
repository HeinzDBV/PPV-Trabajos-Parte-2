using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallPreventing : MonoBehaviour
{
    private Scene CurrentScene;

    private bool playerInRange;
    private void Awake() 
    {
        CurrentScene = SceneManager.GetActiveScene();
        print(CurrentScene.name);
        playerInRange = false;
    }

    private void Update() 
    {
        if(playerInRange == true && CurrentScene.name == "Nivel 0")
        {
            SceneManager.LoadScene("Nivel -1");
            
        }
        else if(playerInRange == true && CurrentScene.name == "Nivel 1")
        {
            SceneManager.LoadScene("Nivel -1");
        }
        else if(playerInRange == true && CurrentScene.name == "Nivel 2")
        {
            SceneManager.LoadScene("Nivel -2");
        }
        else if(playerInRange == true && CurrentScene.name == "Nivel 3")
        {
            SceneManager.LoadScene("Nivel -3");
        }
        else if(playerInRange == true && CurrentScene.name == "Nivel 4")
        {
            SceneManager.LoadScene("Nivel -4");
        }
        else if(playerInRange == true && CurrentScene.name == "Nivel -1")
        {
            SceneManager.LoadScene("Nivel -2");
        }
        else if(playerInRange == true && CurrentScene.name == "Nivel -2")
        {
            SceneManager.LoadScene("Nivel -3");
        }            
        else if(playerInRange == true && CurrentScene.name == "Nivel -3")
        {
            SceneManager.LoadScene("Nivel -4");
        }  
        else if(playerInRange == true && CurrentScene.name == "Nivel -4")
        {
            SceneManager.LoadScene("Final Malo");
        }
                                       
    }

    private void OnTriggerEnter(Collider collision)
    {
        playerInRange = collision.gameObject.CompareTag("Player") ? true : false;
        print("Cambio");
    }
}