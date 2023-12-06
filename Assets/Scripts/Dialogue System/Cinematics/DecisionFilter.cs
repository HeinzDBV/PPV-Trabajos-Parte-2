using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DecisionFilter : MonoBehaviour
{
    [SerializeField] private string Good;
    [SerializeField] private string Bad;
    //private Collider extCollider;
    public static bool controlCheck;
    private bool playerInRange = false;

    private void Awake() 
    {
        controlCheck = false;
    }
    private void Start() 
    {
        //extCollider = GetComponent<Collider>();
        //extCollider.enabled = true;
    }
    private void Update() 
    {
        //controlDoor();
        MakeitBe();
    }


    // public void controlDoor()
    // {
    //     if(controlCheck == false)
    //     {
    //         extCollider.enabled = false;
    //     }
    //     else
    //     {
    //         extCollider.enabled = true;
    //     }

    // }

    public void MakeitBe()
    {
        if(DialogueManager.decision == true && playerInRange == true)
        {
            SceneManager.LoadScene(Good);
        }
        else if(DialogueManager.decision == false && playerInRange == true)
        {
            SceneManager.LoadScene(Bad);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        playerInRange = collision.gameObject.CompareTag("Player") ? true : false;
        print("Cambio");
    }
}
