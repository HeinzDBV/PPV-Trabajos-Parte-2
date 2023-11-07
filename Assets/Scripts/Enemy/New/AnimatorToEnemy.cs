using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorToEnemy : MonoBehaviour
{
    public Enemy Enemy { get; private set; }

    private void Awake()
    {
        Enemy = GetComponentInParent<Enemy>();
    }

    public void AnimationFinishTrigger()
    {
        Enemy.AnimationFinishTrigger();
    }

    public void AnimationActionTrigger()
    {
        Enemy.AnimationActionTrigger();
    }
}
