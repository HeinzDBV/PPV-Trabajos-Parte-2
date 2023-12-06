using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public float TimeToRotate = 2f;
    public float SpeedWalk = 6f;
    public float SpeedRun = 12f;

    public float ViewRadius = 15f;
    [Range(0, 360)]
    public float ViewRange = 110f;
    public float AttackRange = 2f;

    public float PatrolWaitTime = 2f;
    public float ChaseWaitTime = 2f;

    public LayerMask TargetMask;
    public LayerMask ObstacleMask;

}
