using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GunsAmmoUwU : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI CurrentAmmo;

    [SerializeField]
    private TextMeshProUGUI CurrentMaxAmmo;

    private void Start() 
    {
        Gun.OnCurrentAmmoChanged += OnCurrentAmmoChanged;
        Gun.OnCurrentMaxAmmo += OnCurrentMaxAmmo;

    }

    public void OnCurrentAmmoChanged(int CurrentAmmo)
    {
        this.CurrentAmmo.text = CurrentAmmo.ToString();
    }

    public void OnCurrentMaxAmmo(int CurrentMaxAmmo)
    {
        this.CurrentMaxAmmo.text = CurrentMaxAmmo.ToString();
    }
    
}
