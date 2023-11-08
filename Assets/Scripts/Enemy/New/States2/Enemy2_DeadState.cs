using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_DeadState : EnemyState
{
    public Enemy2 enemy2;
    public Enemy2_DeadState(Enemy2 enemy, EnemyStateMachine stateMachine, EnemyData enemyData) : base(enemy, stateMachine, enemyData)
    {
        enemy2 = enemy;
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
