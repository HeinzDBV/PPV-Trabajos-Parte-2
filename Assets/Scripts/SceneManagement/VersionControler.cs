using UnityEngine;
using UnityEngine.SceneManagement;

public class VersionControler : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
    #if UNITY_WEBGL
        SceneManager.LoadScene("Main Menu WebGL");
    #elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        SceneManager.LoadScene("Main Menu PC");
    #endif     
    }
}
