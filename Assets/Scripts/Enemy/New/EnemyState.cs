using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;
    protected EnemyData enemyData;

    protected bool isAnimationFinished;
    protected float startTime;

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.enemyData = enemyData;
        isAnimationFinished = false;
    }

    public virtual void Enter()
    {
        DoChecks();
        startTime = Time.time;
        isAnimationFinished = false;
    }

    public virtual void Exit() { }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks() { }

    public virtual void OnTriggerEnter(Collider other) { }

    public virtual void OnTriggerExit(Collider other) { }

    public virtual void AnimationStartTrigger() { }

    public virtual void AnimationActionTrigger() { }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;

    public virtual void TriggerAttack() { }
}
