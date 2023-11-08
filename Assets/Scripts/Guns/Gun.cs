using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunStats Stats;
    public Transform ShootPoint;

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
            return;
        }

        //Animation
            
        //SFX

        CurrentAmmo--;
        OnCurrentAmmoChanged?.Invoke(CurrentAmmo);
        GameObject particles = Instantiate(Stats.Particles, ShootPoint.position, ShootPoint.rotation);
        GameObject bullet = Instantiate(Stats.BulletPrefab, ShootPoint.position, ShootPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = ShootPoint.forward * Stats.BulletSpeed;
        bullet.GetComponent<Bullet>().Initialize(Stats.Damage, Stats.BulletSpeed, Stats.Range, gameObject);
    }

    public void Reload()
    {
        if (CurrentTotalAmmo <= 0)
        {
            //SFX NO AMMO
            return;
        }

        //Animation

        //SFX

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
