using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    #region State Machine
    public Enemy_IdleState IdleState { get; private set; }
    public Enemy_ChaseState ChaseState { get; private set; }
    public Enemy_AttackState AttackState { get; private set; }
    public Enemy_DeadState DeadState { get; private set; }
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

    public Transform Target { get; set; }

    private void Awake() 
    {
        StateMachine = new EnemyStateMachine();
        IdleState = new Enemy_IdleState(this, StateMachine, EnemyData);
        ChaseState = new Enemy_ChaseState(this, StateMachine, EnemyData);
        AttackState = new Enemy_AttackState(this, StateMachine, EnemyData);
        DeadState = new Enemy_DeadState(this, StateMachine, EnemyData);

        RB = GetComponent<Rigidbody>();
        Anim = GetComponentInChildren<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Start() 
    {
        StateMachine.Initialize(IdleState);
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

    public void SetVelocity(Vector3 velocity)
    {
        RB.velocity = velocity;
    }
}
