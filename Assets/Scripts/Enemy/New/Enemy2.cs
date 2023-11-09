using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : Enemy
{
    #region State Machine
    public new Enemy2_IdleState IdleState { get; private set; }
    public new Enemy2_ChaseState ChaseState { get; private set; }
    public new Enemy2_AttackState AttackState { get; private set; }
    public new Enemy2_DeadState DeadState { get; private set; }
    public new Enemy2_HurtState HurtState { get; private set; }
    public new EnemyStateMachine StateMachine { get; private set; }
    #endregion

    public GameObject bulletPrefab;
    public SoundManager soundManager;

    public override void Awake() 
    {
        StateMachine = new EnemyStateMachine();
        IdleState = new Enemy2_IdleState(this, StateMachine, EnemyData);
        ChaseState = new Enemy2_ChaseState(this, StateMachine, EnemyData);
        AttackState = new Enemy2_AttackState(this, StateMachine, EnemyData);
        HurtState = new Enemy2_HurtState(this, StateMachine, EnemyData);
        DeadState = new Enemy2_DeadState(this, StateMachine, EnemyData);

        RB = GetComponent<Rigidbody>();
        Anim = GetComponentInChildren<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }

    public override void Start() 
    {
        StateMachine.Initialize(IdleState);

        CurrentHealth = EnemyData.MaxHealth;
        isDead = false;
    }

    public override void Update() 
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    public override void FixedUpdate() 
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public override void OnTriggerEnter(Collider other) 
    {
        StateMachine.CurrentState.OnTriggerEnter(other);
    }

    public override void OnTriggerExit(Collider other) 
    {
        StateMachine.CurrentState.OnTriggerExit(other);
    }

    public override void OnTriggerStay(Collider other) 
    {
        StateMachine.CurrentState.OnTriggerStay(other);
    }

    public override void AnimationActionTrigger()
    {
        StateMachine.CurrentState.AnimationActionTrigger();
    }

    public override void AnimationFinishTrigger()
    {
        StateMachine.CurrentState.AnimationFinishTrigger();
    }

    public void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefab, AttackPoint.position, Quaternion.identity);
        bullet.transform.LookAt(Target);
        bullet.transform.Rotate(-10f, 0f, 0f);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 10f, ForceMode.Impulse);
        bullet.GetComponent<Bullet>().Initialize(EnemyData.AttackDamage, EnemyData.AttackCooldown, EnemyData.AttackRange, gameObject);
    }

    public override void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Die();
        }
        else
        {
            StateMachine.ChangeState(HurtState);
        }
    }

    public override void Die()
    {
        if (isDead) return;
        isDead = true;
        StateMachine.ChangeState(DeadState);
    }
}
