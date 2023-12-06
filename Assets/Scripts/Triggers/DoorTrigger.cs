using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private bool DoorOpen = false;
    private bool playerInRange;
    public Transform DoorBisagra;

    // Update is called once per frame
    void Update()
    {
        //Si se oprime el boton de interaccion
        if (InputManager.GetInstance().GetInteractPressed() && DoorOpen == false)
        {
            DoorBisagra.rotation = new Quaternion(0, DoorBisagra.rotation.y + 90, 0, 0);
            DoorOpen = true;
        }
        else if (InputManager.GetInstance().GetInteractPressed() && DoorOpen == true) 
        {
            DoorBisagra.rotation = new Quaternion(0, DoorBisagra.rotation.y - 90, 0, 0);
            DoorOpen = false;
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        //Si el Objeto colisionado tiene la etiqueta de PLAYER -> Activamos Flag
        playerInRange = collision.gameObject.CompareTag("Player") ? true : false;
    }

    private void OnTriggerExit(Collider collision)
    {
        //Si el Objeto colisionado tiene la etiqueta de PLAYER -> Desactivamos flag
        playerInRange = collision.gameObject.CompareTag("Player") ? false : true;
    }
}
