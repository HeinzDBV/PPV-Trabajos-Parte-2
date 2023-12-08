using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    #region State Machine

    public EnemyStateMachine StateMachine { get; protected set; }
    public EnemyState PatrolState { get; protected set; }
    public EnemyState ChaseState { get; protected set; }
    public EnemyState IdleState { get; protected set; }

    [SerializeField]
    private EnemyData enemyData;

    #endregion

    #region Components

    public NavMeshAgent NavMeshAgent { get; private set; }
    public Animator Animator { get; private set; }
    #endregion

    #region Other Variables
    public Transform[] Waypoints;
    public int CurrentWaypointIndex { get; set; }
    public bool IsPlayerInSight { get; set; }
    public Transform PlayerPosition { get; set; }
    public Vector3 PlayerLastPosition { get; set; }
    public GameObject Player { get; set; }
    public PlayerMovement PlayerMovement { get; set; }
    public DefeatByMonster defeatByMonster;

    #endregion

    void Awake()
    {
        StateMachine = new EnemyStateMachine();

        PatrolState = new PatrolState(this, StateMachine, enemyData);
        ChaseState = new ChaseState(this, StateMachine, enemyData);
        IdleState = new IdleState(this, StateMachine, enemyData);

        NavMeshAgent = GetComponent<NavMeshAgent>();

        PlayerLastPosition = Vector3.zero;
        Player = GameObject.Find("Player");
        PlayerMovement = Player.GetComponent<PlayerMovement>();
        Animator = GetComponentInChildren<Animator>();

        defeatByMonster = GetComponent<DefeatByMonster>();
    }

    void Start()
    {
        StateMachine.Initialize(PatrolState);
    }

    
    void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
        Debug.DrawRay(transform.position, transform.forward * enemyData.ViewRadius);
    }

    void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetDestination(Vector3 destination)
    {
        NavMeshAgent.SetDestination(destination);
    }

    public void LookingPlayer(Vector3 player)
    {
        NavMeshAgent.SetDestination(player);

        if (Vector3.Distance(transform.position, player) <= enemyData.AttackRange)
        {
            
        }
    }

    public void Move(float speed)
    {
        NavMeshAgent.isStopped = false;
        NavMeshAgent.speed = speed;
    }

    public void Stop()
    {
        NavMeshAgent.isStopped = true;
        NavMeshAgent.speed = 0;
    }

    public void NextWaypoint()
    {
        CurrentWaypointIndex = (CurrentWaypointIndex + 1) % Waypoints.Length;
        SetDestination(Waypoints[CurrentWaypointIndex].position);
    }

    public void EnvironmentView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, enemyData.ViewRadius, enemyData.TargetMask);
        
        foreach (Collider player in playerInRange)
        {
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, directionToPlayer) < enemyData.ViewRange / 2)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

                if (!Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer, enemyData.ObstacleMask))
                {
                    IsPlayerInSight = true;
                }
                else
                {
                    IsPlayerInSight = false;
                }
            }
            if (Vector3.Distance(transform.position, player.transform.position) > enemyData.ViewRadius)
            {
                IsPlayerInSight = false;
            }
        }

        if (IsPlayerInSight)
        {
            PlayerPosition = playerInRange[0].transform;
        }
    }
}
