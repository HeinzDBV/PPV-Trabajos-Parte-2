using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyStateOld
{
    Idle, Follow, Attacking
}

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Transform Player;
    private float DistanceToFollow = 5;

    private float DistanceToAttack = 1;

    private EnemyStateOld state = EnemyStateOld.Idle;

    private void Update()
    {
        
    } 
    
}
