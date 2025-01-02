using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private HealthUI healthUI;

    private int health;

    public int Health
    {
        get
        {
            return health;
        }
        private set
        {
            health = value;
            healthUI.UpdateHealthText(Health);
        }
    }

    private void Start()
    {
        Health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        int healthAfterDamage = Math.Clamp(health - damage, 0, maxHealth);
        Health = healthAfterDamage;

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
        GameManager.instance.RestartLevel();
    }
}
