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
        Debug.Log("Bullet Start: " + TimeAlive);
        Destroy(gameObject, TimeAlive);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != Owner)
        {
            Debug.Log(other.gameObject);
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<IDamageable>().TakeDamage(Damage);
            }
            else if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);
            }
            Destroy(gameObject);
        }
    }
}
