using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatByMonster : MonoBehaviour
{

    private Scene CurrentScene;

    private bool playerCatched;
    private void Awake() 
    {
        CurrentScene = SceneManager.GetActiveScene();
        print(CurrentScene.name);
        playerCatched = false;
    }

    public void ChangeLevel()
    {
        CurrentScene = SceneManager.GetActiveScene();

        if(CurrentScene.name == "Nivel 0")
        {
            SceneManager.LoadScene("Nivel -1");
        }
        else if(CurrentScene.name == "Nivel 1")
        {
            SceneManager.LoadScene("Nivel -1");
        }
        else if(CurrentScene.name == "Nivel 2")
        {
            SceneManager.LoadScene("Nivel -2");
        }
        else if(CurrentScene.name == "Nivel 3")
        {
            SceneManager.LoadScene("Nivel -3");
        }
        else if(CurrentScene.name == "Nivel 4")
        {
            SceneManager.LoadScene("Nivel -4");
        }
        else if(CurrentScene.name == "Nivel -1")
        {
            SceneManager.LoadScene("Nivel -2");
        }
        else if(CurrentScene.name == "Nivel -2")
        {
            SceneManager.LoadScene("Nivel -3");
        }            
        else if(CurrentScene.name == "Nivel -3")
        {
            SceneManager.LoadScene("Nivel -4");
        }  
        else if(CurrentScene.name == "Nivel -4")
        {
            SceneManager.LoadScene("Final Malo");
        }
        else
        {
            Debug.Log("MUERTO");
        }                         
    }

    private void OnTriggerEnter(Collider collision)
    {
        playerCatched = collision.gameObject.CompareTag("Player") ? true : false;
        print("Cambio");
    }
}
