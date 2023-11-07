using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DeadState : EnemyState
{
    public Enemy_DeadState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData) : base(enemy, stateMachine, enemyData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        enemy.SetVelocity(Vector3.zero);
        enemy.Anim.SetTrigger("IsDead");
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        GameObject.Destroy(enemy.gameObject);
    }
}
