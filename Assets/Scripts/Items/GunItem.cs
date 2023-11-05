using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour, IInteractable
{
    public GameObject GunPrefab;

    public void Interact()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerFire>().EquipGun(GunPrefab);
        Destroy(gameObject);
    }
}
