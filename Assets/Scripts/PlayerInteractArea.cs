using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractArea : MonoBehaviour
{
    public List<GameObject> InteractableObjects { get; set; }

    public void Start()
    {
        InteractableObjects = new List<GameObject>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            InteractableObjects.Add(other.gameObject);
            CleanList();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            InteractableObjects.Remove(other.gameObject);
            CleanList();
        }
    }

    private void CleanList()
    {
        InteractableObjects.RemoveAll(item => item == null);
    }

    public void Interact()
    {
        if (InteractableObjects.Count > 0)
        {
            GetClosestInteractable().Interact();
        }
    }

    private IInteractable GetClosestInteractable()
    {
        GameObject closestInteractable = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject interactable in InteractableObjects)
        {
            var distance = Vector3.Distance(transform.position, interactable.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestInteractable = interactable;
            }
        }

        return closestInteractable.GetComponent<IInteractable>();
    }
}
