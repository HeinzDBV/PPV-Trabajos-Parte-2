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
    private EnemyData EnemyData;
    #endregion

    #region Components
    public Transform AttackPoint;
    public Rigidbody RB { private set; get; }
    public Animator Anim { private set; get; }
    public NavMeshAgent Agent { private set; get; }
    #endregion

    #region Variables
    public float CurrentHealth { get; private set; }
    #endregion

    public Transform Target { get; set; }

    private void Awake() 
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

    private void Start() 
    {
        StateMachine.Initialize(IdleState);

        CurrentHealth = EnemyData.MaxHealth;
    }

    private void Update() 
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate() 
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    private void OnTriggerEnter(Collider other) 
    {
        StateMachine.CurrentState.OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other) 
    {
        StateMachine.CurrentState.OnTriggerExit(other);
    }

    private void OnTriggerStay(Collider other) 
    {
        StateMachine.CurrentState.OnTriggerStay(other);
    }

    public void AnimationActionTrigger()
    {
        StateMachine.CurrentState.AnimationActionTrigger();
    }

    public void AnimationFinishTrigger()
    {
        StateMachine.CurrentState.AnimationFinishTrigger();
    }

    public void SetVelocity(Vector3 velocity)
    {
        RB.velocity = velocity;
    }

    public void TakeDamage(float damage)
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

    public void Die()
    {
        StateMachine.ChangeState(DeadState);
    }
}
