using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{
    #region State Machine
    public Enemy_IdleState IdleState { get; private set; }
    public Enemy_ChaseState ChaseState { get; private set; }
    public Enemy_AttackState AttackState { get; private set; }
    public Enemy_DeadState DeadState { get; private set; }
    public Enemy_HurtState HurtState { get; private set; }
    public EnemyStateMachine StateMachine { get; private set; }
    [SerializeField]
    protected EnemyData EnemyData;
    #endregion

    #region Components
    public Transform AttackPoint;
    public Rigidbody RB { protected set; get; }
    public Animator Anim { protected set; get; }
    public NavMeshAgent Agent { protected set; get; }
    #endregion

    #region Variables
    public float CurrentHealth { get; protected set; }
    #endregion

    public Transform Target { get; set; }
    protected bool isDead;

    public virtual void Awake() 
    {
        StateMachine = new EnemyStateMachine();
        IdleState = new Enemy_IdleState(this, StateMachine, EnemyData);
        ChaseState = new Enemy_ChaseState(this, StateMachine, EnemyData);
        AttackState = new Enemy_AttackState(this, StateMachine, EnemyData);
        HurtState = new Enemy_HurtState(this, StateMachine, EnemyData);
        DeadState = new Enemy_DeadState(this, StateMachine, EnemyData);

        RB = GetComponent<Rigidbody>();
        Anim = GetComponentInChildren<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }

    public virtual void Start() 
    {
        StateMachine.Initialize(IdleState);

        CurrentHealth = EnemyData.MaxHealth;
        isDead = false;
    }

    public virtual void Update() 
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    public virtual void FixedUpdate() 
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public virtual void OnTriggerEnter(Collider other) 
    {
        StateMachine.CurrentState.OnTriggerEnter(other);
    }

    public virtual void OnTriggerExit(Collider other) 
    {
        StateMachine.CurrentState.OnTriggerExit(other);
    }

    public virtual void OnTriggerStay(Collider other) 
    {
        StateMachine.CurrentState.OnTriggerStay(other);
    }

    public virtual void AnimationActionTrigger()
    {
        StateMachine.CurrentState.AnimationActionTrigger();
    }

    public virtual void AnimationFinishTrigger()
    {
        StateMachine.CurrentState.AnimationFinishTrigger();
    }

    public void SetVelocity(Vector3 velocity)
    {
        RB.velocity = velocity;
    }

    public virtual void TakeDamage(float damage)
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

    public virtual void Die()
    {
        if (isDead) return;
        isDead = true;
        StateMachine.ChangeState(DeadState);
    }
}
