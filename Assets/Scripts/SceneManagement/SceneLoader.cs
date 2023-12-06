using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void MainMenuChrg()
    {
        SceneManager.LoadScene("Pre-Charge");
    }
    public void Lev0Chrg()
    {
        SceneManager.LoadScene("Nivel 0");
    }
    
    public void Lev1Chrg()
    {
        SceneManager.LoadScene("Nivel 1");
    }
    
    public void Lev2Chrg()
    {
        SceneManager.LoadScene("Nivel 2");
    }
    
    public void Lev3Chrg()
    {
        SceneManager.LoadScene("Nivel 3");
    }
    public void Lev4Chrg()
    {
        SceneManager.LoadScene("Nivel 4");
    }
    
    public void Levn1Chrg()
    {
        SceneManager.LoadScene("Nivel -1");
    }
    
    public void Levn2Chrg()
    {
        SceneManager.LoadScene("Nivel -2");
    }
    public void Levn3Chrg()
    {
        SceneManager.LoadScene("Nivel -3");
    }
    public void Levn4Chrg()
    {
        SceneManager.LoadScene("Nivel -4");
    }
    public void GoodEndingChrg()
    {
        SceneManager.LoadScene("Final Bueno");
    }
    public void BadEndingChrg()
    {
        SceneManager.LoadScene("Final Malo");
    }
    public void Exit()
    {
        Application.Quit();
    }

}
