using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyState
{
    public float waitTime;

    public PatrolState(EnemyController enemy, EnemyStateMachine stateMachine, EnemyData enemyData) : base(enemy, stateMachine, enemyData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        waitTime = enemyData.PatrolWaitTime;
        Debug.Log("Enter Patrol State");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemy.EnvironmentView();

        if (enemy.NavMeshAgent.remainingDistance <= enemy.NavMeshAgent.stoppingDistance)
        {
            if (waitTime <= 0)
            {
                enemy.NextWaypoint();
                enemy.Move(enemyData.SpeedWalk);
                waitTime = enemyData.PatrolWaitTime;
            }
            else
            {
                enemy.Stop();
                waitTime -= Time.deltaTime;
            }
        }
        else if (enemy.IsPlayerInSight)
        {
            Debug.Log("Player in sight");
            stateMachine.ChangeState(enemy.ChaseState);
        }
        else
        {
            enemy.SetDestination(enemy.Waypoints[enemy.CurrentWaypointIndex].position);
            enemy.Move(enemyData.SpeedWalk);
        }
    }

}
