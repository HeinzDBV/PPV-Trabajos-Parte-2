using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFaces : MonoBehaviour
{
    private Animator animator;   
   
    #region Components
    public PlayerStats playerStats;
    #endregion

    private float CurrentHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
        CurrentHealth = playerStats.MaxHealth;
        animator.SetFloat("CurrentHealth", CurrentHealth);  
    }

    void Update()
    {
        CurrentHealth = playerStats.MaxHealth;
        animator.SetFloat("CurrentHealth", CurrentHealth);
    }

}
