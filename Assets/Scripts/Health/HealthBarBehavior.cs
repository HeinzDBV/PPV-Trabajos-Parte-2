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
        PlayerHealth.OnHealthChanged += UpdateHealthBar;
        PlayerHealth.OnMaxHealthChanged += UpdateMaxHealthBar;
    
        PlayerHealth.OnShieldChanged += UpdateShieldBar;
        PlayerHealth.OnMaxShieldChanged += UpdateMaxShieldBar;
    }

    private void Update()
    {
            
    }
    // void Update()
    // {
    //     HealthAnimator.SetFloat("CurrentHealth", CurrentHealth);
    //     ShieldAnimator.SetFloat("CurrentShield", CurrentShield);
    // }

    public void UpdateHealthBar(float health)
    {
        CurrentHealth = health;
        HealthAnimator.SetFloat("CurrentHealth", CurrentHealth);

    }
    public void UpdateShieldBar(float shield)
    {
        CurrentShield = shield;
        ShieldAnimator.SetFloat("CurrentShield", CurrentShield);

    }

    public void UpdateMaxHealthBar(float maxHealth)
    {
        MaxHealth = maxHealth;
    }
    public void UpdateMaxShieldBar(float maxHealth)
    {
        MaxHealth = maxHealth;
    }
}
