using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunStats", menuName = "ScriptableObjects/GunStats", order = 1)]
public class GunStats : ScriptableObject
{
    public float Damage;
    public float FireRate;
    public float Range;
    public float ReloadTime;
    public int MaxAmmo;
    public int TotalAmmo;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    public GameObject Particles;
    public AudioClip ShootSound;
    public GunType gunsType;
}
