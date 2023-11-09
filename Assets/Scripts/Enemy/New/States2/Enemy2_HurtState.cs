using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_HurtState : EnemyState
{
    public Enemy2 enemy2;
    public Enemy2_HurtState(Enemy2 enemy, EnemyStateMachine stateMachine, EnemyData enemyData) : base(enemy, stateMachine, enemyData)
    {
        enemy2 = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy2.SetVelocity(Vector3.zero);
        enemy2.Anim.SetTrigger("IsHit");
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        enemy2.StateMachine.ChangeState(enemy2.IdleState);
    }
}
