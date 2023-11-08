using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_ChaseState : EnemyState
{
    public Enemy2 enemy2;
    public Vector3 dir;

    public Enemy2_ChaseState(Enemy2 enemy2, EnemyStateMachine stateMachine, EnemyData enemyData) : base(enemy2, stateMachine, enemyData)
    {
        this.enemy2 = enemy2;
    }

    public override void Enter()
    {
        base.Enter();

        enemy2.Anim.SetBool("IsWalking", true);
    }

    public override void Exit()
    {
        base.Exit();

        enemy2.Anim.SetBool("IsWalking", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (dir.magnitude <= enemyData.AttackRange)
        {
            stateMachine.ChangeState(enemy2.AttackState);
        }
        else
        {
            Chase();
        }
        
    }

    public void Chase()
    {
        Quaternion desiredRotation = Quaternion.LookRotation(dir);
        
        enemy2.transform.rotation = Quaternion.Lerp(
            enemy2.transform.rotation,
            desiredRotation,
            0.1f
        );
        
        enemy2.Agent.destination = enemy2.Target.position;
        Debug.Log( "estas en " + enemy2.Target.position);
    }

    public override void DoChecks()
    {
        base.DoChecks();

        dir = enemy2.Target.position -  enemy2.transform.position;
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (other.CompareTag("Player"))
        {
            enemy2.Target = null;
            stateMachine.ChangeState(enemy2.IdleState);
        }
    }
}
