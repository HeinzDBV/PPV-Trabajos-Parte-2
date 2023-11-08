using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsUI : MonoBehaviour
{
    [SerializeField]
    private List <GameObject> Armas;
    public Animator animator;
    private void Start() 
    {
        animator = GetComponent<Animator>();
    }
    
    public void ShowGun(GunType index)
    {
        foreach(GunType gunType in (GunType[]) Enum.GetValues(typeof(GunType)))
        {
            if(gunType != GunType.NONE)
            animator.SetBool($"{gunType.ToString()}",false);
        }
        if(index != GunType.NONE)
        {
            animator.SetBool($"{index.ToString()}",true);
        }
    }

}
public enum GunType
{
    NONE,
    PISTOLA,
    BANANA,
    RIFLE,
}