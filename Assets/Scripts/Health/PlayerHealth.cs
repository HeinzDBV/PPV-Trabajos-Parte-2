using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float MaxHealth;
    private float MaxShield;
    [SerializeField]
    private float CurrentHealth;
    private float CurrentShield;

    
    [SerializeField]
    private GameObject Deadscreen;

    #region Components
    public Animator Animator { get; private set;}
    public Animator Animator2;
    public SoundManager soundManager;
    public PlayerStats playerStats;
    #endregion
    
    #region Events
    public static event Action<float> OnHealthChanged;
    public static event Action<float> OnMaxHealthChanged;
    public static event Action<float> OnShieldChanged;
    public static event Action<float> OnMaxShieldChanged;
    #endregion

    private void Awake() 
    {
        Deadscreen.SetActive(false);    
    }
    void Start()
    {
        Animator = GetComponent<Animator>();

        MaxHealth = playerStats.MaxHealth;
        CurrentHealth = MaxHealth;

        MaxShield = playerStats.MaxShield;
        CurrentShield = MaxShield;
        
        OnHealthChanged?.Invoke(CurrentHealth);
        OnMaxHealthChanged?.Invoke(MaxHealth);

        OnShieldChanged?.Invoke(CurrentShield);
        OnMaxShieldChanged?.Invoke(MaxShield);
    }

    public void TakeDamage(float damage)
    {
        Animator2.SetTrigger("Hit");
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        int randomSFX = UnityEngine.Random.Range(5, 10);
        soundManager.PlaySFX(randomSFX);


        if(CurrentShield > 0)
        {
            CurrentShield -= damage;
            OnShieldChanged?.Invoke(CurrentShield);
        }
        else
        {
            CurrentHealth -= damage;
            OnHealthChanged?.Invoke(CurrentHealth);
            Animator2.SetFloat("CurrentHealth", CurrentHealth);  
        }


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

    public void RecoverShield(float Shield)
    {
        CurrentShield += Shield;
        OnShieldChanged?.Invoke(CurrentShield);

        if (CurrentShield > MaxShield)
        {
            CurrentShield = MaxShield;
        }
    }

    public void Die()
    {
        Time.timeScale = 1f;
        Deadscreen.SetActive(true);
        Debug.Log("Player died");
    }
}
