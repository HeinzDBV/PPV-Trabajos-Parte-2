using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HurtState : EnemyState
{
    public Enemy_HurtState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData) : base(enemy, stateMachine, enemyData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        enemy.SetVelocity(Vector3.zero);
        enemy.Anim.SetTrigger("IsHit");
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        enemy.StateMachine.ChangeState(enemy.IdleState);
    }
}
