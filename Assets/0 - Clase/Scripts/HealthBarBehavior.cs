using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBehavior : MonoBehaviour
{
    public float MaxHealth = 100f;
    public float CurrentHealth = 100f;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        
        PlayerHealth.OnHealthChanged += UpdateHealthBar;
        PlayerHealth.OnMaxHealthChanged += UpdateMaxHealthBar;
    }

    public void UpdateHealthBar(float health)
    {
        CurrentHealth = health;
        UpdateAnimation();
    }

    public void UpdateMaxHealthBar(float maxHealth)
    {
        MaxHealth = maxHealth;
    }

    public void UpdateAnimation()
    {
        
    }
}
