using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunStats Stats;
    public Transform ShootPoint;

    public SoundManager soundManager;

    public int CurrentAmmo { get; private set; }
    public int CurrentTotalAmmo { get; private set; }
    public GameObject ItemPrefab;
    public static event Action<int> OnCurrentAmmoChanged;
    public static event Action<int> OnCurrentMaxAmmo;
    public static event Action<int> OnGunSelected;

    public void Awake()
    {
        CurrentAmmo = Stats.MaxAmmo;
        CurrentTotalAmmo = Stats.TotalAmmo;
    }

    public void Shoot()
    {
        if (CurrentAmmo <= 0)
        {
            //SFX NO AMMO
            soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
            soundManager.PlaySFX(0);

            return;
        }

        //Animation

        //SFX
        if (Stats.gunsType == GunType.BANANA)
        {
            Debug.Log("BANANA");
            soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
            soundManager.PlaySFX(2);
        }
        else if(Stats.gunsType == GunType.PISTOLA){
            soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
            soundManager.PlaySFX(3);
            Debug.Log("PISTOLA");
        }
        else if(Stats.gunsType == GunType.RIFLE){
            Debug.Log("RIFLE");
            soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
            soundManager.PlaySFX(4);
        }
        
        CurrentAmmo--;
        OnCurrentAmmoChanged?.Invoke(CurrentAmmo);
        GameObject particles = Instantiate(Stats.Particles, ShootPoint.position, ShootPoint.rotation * Quaternion.Euler(0, 90, 90));
        Debug.Log(ShootPoint.rotation);
        GameObject bullet = Instantiate(Stats.BulletPrefab, ShootPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = Stats.BulletSpeed * ShootPoint.right;
        bullet.GetComponent<Bullet>().Initialize(Stats.Damage, Stats.BulletSpeed, Stats.Range, gameObject);
    }

    public void Reload()
    {
        if (CurrentTotalAmmo <= 0)
        {
            //SFX NO AMMO
            soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
            soundManager.PlaySFX(1);
            return;
        }

        //Animation

        //SFX
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        soundManager.PlaySFX(1);


        int ammoNeeded = Stats.MaxAmmo - CurrentAmmo;
        if (CurrentTotalAmmo >= ammoNeeded)
        {
            CurrentTotalAmmo -= ammoNeeded;
            CurrentAmmo = Stats.MaxAmmo;
        }
        else
        {
            CurrentAmmo += CurrentTotalAmmo;
            CurrentTotalAmmo = 0;
        }
        OnCurrentAmmoChanged?.Invoke(CurrentAmmo);
    }

    public void GunSelected()
    {
        OnCurrentAmmoChanged?.Invoke(CurrentAmmo);
        OnCurrentMaxAmmo?.Invoke(Stats.MaxAmmo);
    }
    public void GunDeselected()
    {
        OnCurrentAmmoChanged?.Invoke(0);
        OnCurrentMaxAmmo?.Invoke(0);
    }
}
