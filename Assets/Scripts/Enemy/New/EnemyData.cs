using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Enemy Data/Base Enemy Data")]
public class EnemyData : ScriptableObject
{
    public float MaxHealth = 100f;
    public float AttackDamage = 10f;
    public float AttackRange = 3f;
    public float AttackCooldown = 2f;
    public LayerMask WhatIsPlayer;
}

