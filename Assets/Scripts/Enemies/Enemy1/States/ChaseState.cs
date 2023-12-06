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

        enemy.PlayerLastPosition = enemy.Player.transform.position;
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
        
        enemy.EnvironmentView();

        if (Vector3.Distance(enemy.transform.position, enemy.Player.transform.position) <= enemyData.AttackRange && !enemy.PlayerMovement.IsHidden)
        {
            enemy.Stop();
            enemy.defeatByMonster.ChangeLevel();
        }
        else if (enemy.NavMeshAgent.remainingDistance <= enemy.NavMeshAgent.stoppingDistance)
        {
            
            if (enemy.IsPlayerInSight)
            {
                enemy.PlayerLastPosition = enemy.Player.transform.position;
                waitTime = enemyData.ChaseWaitTime;
                enemy.SetDestination(enemy.PlayerLastPosition);
                enemy.Move(enemyData.SpeedRun);
            }
            else
            {
                if (waitTime <= 0)
                {
                    enemy.StateMachine.ChangeState(enemy.PatrolState);
                }
                else
                {
                    enemy.Stop();
                    waitTime -= Time.deltaTime;
                }
            }
        }
        else if (enemy.IsPlayerInSight)
        {
            enemy.PlayerLastPosition = enemy.Player.transform.position;
            enemy.SetDestination(enemy.PlayerLastPosition);
            enemy.Move(enemyData.SpeedRun);
        }
        else 
        {
            if (waitTime <= 0)
            {
                enemy.StateMachine.ChangeState(enemy.PatrolState);
            }
            else
            {
                enemy.Stop();
                waitTime -= Time.deltaTime;
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
