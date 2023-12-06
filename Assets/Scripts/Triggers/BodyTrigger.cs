using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTrigger : MonoBehaviour
{
    private string bodylocal = DialogueManager.body;
    [SerializeField] private Transform pbody;
    // Start is called before the first frame update
    void Start()
    {
        print(bodylocal);
        print(pbody);
    }

    // Update is called once per frame
    void Update()
    {
        bodylocal = DialogueManager.body;

        if(bodylocal == "uno")
        {
            pbody.position = new Vector3(-13f, 0, 57); 
            pbody.rotation = new Quaternion(0,-90,0,0);
        }
        else if(bodylocal == "dos")
        {
            pbody.position = new Vector3(-19.74f, -1.2f, 53.37f); 
        }
        else
        {
            pbody.position = new Vector3(-14.5f,0,54);
            pbody.rotation = new Quaternion(0,0,0,0);
        }
    }
}
