using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public GameObject InteractItem;
    public IInteractable Interactable;

    public void GetClosestInteractable()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);
        float closestDistance = Mathf.Infinity;
        IInteractable closestInteractable = null;

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestInteractable = interactable;
                }
            }
        }

        Interactable = closestInteractable;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Se presionó la E");
            GetClosestInteractable();
            Interactable?.Interact();
        }
    }

    public void Interact()
    {
        Interactable?.Interact();
        Debug.Log("Se interactuó con item");
    }
}
