using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int Health { get; private set; }

    private void Awake()
    {
        Health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
    }

    public void Kill()
    {
        Health = 0;
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
