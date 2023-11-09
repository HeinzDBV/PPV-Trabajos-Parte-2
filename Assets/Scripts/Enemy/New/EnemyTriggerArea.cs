using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerArea : MonoBehaviour
{
    public Enemy enemy;

    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    public void OnTriggerEnter(Collider other)
    {
        enemy.OnTriggerEnter(other);
    }

    public void OnTriggerExit(Collider other)
    {
        enemy.OnTriggerExit(other);
    }

    public void OnTriggerStay(Collider other)
    {
        enemy.OnTriggerStay(other);
    }
}
