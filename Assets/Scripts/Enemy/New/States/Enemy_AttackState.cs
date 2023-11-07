using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AttackState : EnemyState
{
    public Enemy_AttackState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData) : base(enemy, stateMachine, enemyData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        enemy.SetVelocity(Vector3.zero);
        enemy.Anim.SetTrigger("IsAttacking");
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
            stateMachine.ChangeState(enemy.ChaseState);
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        Collider[] colliders = Physics.OverlapSphere(enemy.AttackPoint.position, enemyData.AttackRange, enemyData.WhatIsPlayer);

        foreach (Collider collider in colliders)
        {
            collider.GetComponent<PlayerHealth>().TakeDamage(enemyData.AttackDamage);
        }
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }
}
