using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float MaxHealth;
    [SerializeField]
    private float CurrentHealth;

    #region Components
    public Animator Animator { get; private set;}
    public PlayerStats playerStats;
    #endregion
    
    #region Events
    public static event Action<float> OnHealthChanged;
    public static event Action<float> OnMaxHealthChanged;
    #endregion

    void Start()
    {
        Animator = GetComponent<Animator>();

        MaxHealth = playerStats.MaxHealth;
        CurrentHealth = MaxHealth;
        
        OnHealthChanged?.Invoke(CurrentHealth);
        OnMaxHealthChanged?.Invoke(MaxHealth);
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        OnHealthChanged?.Invoke(CurrentHealth);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float heal)
    {
        CurrentHealth += heal;
        OnHealthChanged?.Invoke(CurrentHealth);

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }

    public void Die()
    {
        Debug.Log("Player died");
    }
}
