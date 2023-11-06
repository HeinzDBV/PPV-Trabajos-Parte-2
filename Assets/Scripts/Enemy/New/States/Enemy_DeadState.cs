using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DeadState : EnemyState
{
    public Enemy_DeadState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData) : base(enemy, stateMachine, enemyData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        enemy.SetVelocity(new Vector3(0f, 0f, 0f));
        //Play dead animation
        Debug.Log("Dead");
    }
}
