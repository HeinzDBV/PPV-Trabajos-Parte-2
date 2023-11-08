using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_IdleState : EnemyState
{
    public Enemy2 enemy2;
    public Enemy2_IdleState(Enemy2 enemy, EnemyStateMachine stateMachine, EnemyData enemyData) : base(enemy, stateMachine, enemyData)
    {
        enemy2 = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.SetVelocity(Vector3.zero);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("Player"))
        {
            enemy.Target = other.transform;
            stateMachine.ChangeState(enemy2.ChaseState);
        }
    }
}
