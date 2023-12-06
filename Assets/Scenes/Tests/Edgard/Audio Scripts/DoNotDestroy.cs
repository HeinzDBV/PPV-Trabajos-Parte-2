using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");

        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            
            DontDestroyOnLoad(this.gameObject);
            foreach (Transform child in transform)
            {
                Debug.Log("Child: " + child.name);
                DontDestroyOnLoad(child.gameObject);
            }
        }
    }
}
