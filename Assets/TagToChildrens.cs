using UnityEngine;

public class ApplyTagToChildren : MonoBehaviour
{
    public string tagToApply = "Muelle"; // Coloca aquí el tag que deseas aplicar

    void Start()
    {
        ApplyTagRecursively(transform);
    }

    void ApplyTagRecursively(Transform parent)
    {
        foreach (Transform child in parent)
        {
            child.gameObject.tag = tagToApply; // Aplica el tag al GameObject hijo
            ApplyTagRecursively(child); // Llama recursivamente a la función para los hijos del hijo actual
            Debug.Log("Se aplicó el tag " + tagToApply + " al GameObject " + child.gameObject.name);
        }
    }
}
