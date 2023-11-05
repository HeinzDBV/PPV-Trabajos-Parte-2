using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBehavior : MonoBehaviour
{
    public float MaxHealth = 200f;
    public float CurrentHealth = 200f;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        
        animator.SetFloat("CurrentHealth", CurrentHealth);
        PlayerHealth.OnHealthChanged += UpdateHealthBar;
        PlayerHealth.OnMaxHealthChanged += UpdateMaxHealthBar;
    }

    void Update()
    {
        animator.SetFloat("CurrentHealth", CurrentHealth);
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
        animator.SetFloat("CurrentHealth", CurrentHealth);
    }
}
