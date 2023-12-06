using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    [Header("Movement")]
    public float MoveSpeed = 12f;
    public float SprintSpeed = 6f;
    public float CrouchSpeed = 6f;
    public float CrouchTransform = 0.5f;
    public float Gravity = 9.81f;

    [Header("Look")]
    public float SensY = 20f;
    public float SensX = 20f;
}
