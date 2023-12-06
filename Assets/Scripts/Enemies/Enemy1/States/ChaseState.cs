using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{
    public float waitTime;

    public ChaseState(EnemyController enemy, EnemyStateMachine stateMachine, EnemyData enemyData) : base(enemy, stateMachine, enemyData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        enemy.PlayerLastPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        waitTime = enemyData.ChaseWaitTime;

        Debug.Log("Enter Chase State");
    }

    public override void Exit()
    {
        base.Exit();

        enemy.PlayerLastPosition = Vector3.zero;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Vector3.Distance(enemy.transform.position, enemy.PlayerLastPosition) <= enemyData.AttackRange)
        {
            Debug.Log("JUMPSCARE");
        }
        else if (enemy.NavMeshAgent.remainingDistance <= enemy.NavMeshAgent.stoppingDistance)
        {
            enemy.Stop();
            stateMachine.ChangeState(enemy.PatrolState);
        }
        else
        {
            enemy.Move(enemyData.SpeedRun);
            enemy.SetDestination(enemy.PlayerLastPosition);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
