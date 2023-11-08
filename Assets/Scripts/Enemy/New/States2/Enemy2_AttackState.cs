using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_AttackState : EnemyState
{
    public Enemy2 enemy2;
    public Enemy2_AttackState(Enemy2 enemy, EnemyStateMachine stateMachine, EnemyData enemyData) : base(enemy, stateMachine, enemyData)
    {
        enemy2 = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy2.SetVelocity(Vector3.zero);
        enemy2.Anim.SetTrigger("IsAttacking");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            stateMachine.ChangeState(enemy2.ChaseState);
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        enemy2.Attack();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }
}
