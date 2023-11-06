using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ChaseState : EnemyState
{
    public Vector3 dir;

    public Enemy_ChaseState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData) : base(enemy, stateMachine, enemyData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        enemy.SetVelocity(new Vector3(0f, 0f, 0f));
        //Play chase animation
        Debug.Log("Chase: " + enemy.name);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (dir.magnitude <= enemyData.AttackRange)
        {
            stateMachine.ChangeState(enemy.AttackState);
        }
        else
        {
            Chase();
        }
        
    }

    public void Chase()
    {
        Quaternion desiredRotation = Quaternion.LookRotation(dir);
        
        enemy.transform.rotation = Quaternion.Lerp(
            enemy.transform.rotation,
            desiredRotation,
            0.1f
        );
        
        enemy.Agent.destination = enemy.Target.position;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        dir = enemy.Target.position -  enemy.transform.position;
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (other.CompareTag("Player"))
        {
            enemy.Target = null;
            stateMachine.ChangeState(enemy.IdleState);
        }
    }
}
