using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    [Header("Movement")]
    public float MoveSpeed = 12f;
    public float SprintSpeed = 18f;

    [Header("Look")]
    public float SensY = 20f;
    public float SensX = 20f;
}
