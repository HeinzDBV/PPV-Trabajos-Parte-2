using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBehavior : MonoBehaviour
{
    public float MaxHealth = 100f;
    public float CurrentHealth = 100f;

    public float MaxShield = 100f;
    public float CurrentShield = 100f;
    public Animator HealthAnimator;
    public Animator ShieldAnimator;

    void Start()
    {   
        HealthAnimator.SetFloat("CurrentHealth", CurrentHealth);
        ShieldAnimator.SetFloat("CurrentShield", CurrentShield);

        PlayerHealth.OnHealthChanged += UpdateHealthBar;
        PlayerHealth.OnMaxHealthChanged += UpdateMaxHealthBar;
    
        PlayerHealth.OnShieldChanged += UpdateHealthBar;
        PlayerHealth.OnMaxShieldChanged += UpdateMaxHealthBar;
    }

    // void Update()
    // {
    //     HealthAnimator.SetFloat("CurrentHealth", CurrentHealth);
    //     ShieldAnimator.SetFloat("CurrentShield", CurrentShield);
    // }

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
        HealthAnimator.SetFloat("CurrentHealth", CurrentHealth);
        ShieldAnimator.SetFloat("CurrentShield", CurrentShield);
    }
}
