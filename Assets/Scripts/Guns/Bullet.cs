using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    public float Speed;
    public float TimeAlive;
    public GameObject Owner;

    public void Initialize(float damage, float speed, float timeAlive, GameObject owner)
    {
        Damage = damage;
        Speed = speed;
        TimeAlive = timeAlive;
        Owner = owner;
    }

    void Start()
    {
        Destroy(gameObject, TimeAlive);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != Owner)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<IDamageable>().TakeDamage(Damage);
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);
                Destroy(gameObject);
            }
        }
    }
}
