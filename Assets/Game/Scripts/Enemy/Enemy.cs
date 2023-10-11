using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    private Health _health;

    private void Awake()
    {
        _health = new Health(3f);
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    private void OnHealthChanged(float arg1, float arg2)
    {
        if (_health.CurrentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}