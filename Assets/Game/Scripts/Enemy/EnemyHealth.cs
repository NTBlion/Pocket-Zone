using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;

    private Health _health;

    public event Action<float, float> HealthChanged;
    
    private void Awake()
    {
        _health = new Health(_currentHealth, _maxHealth);
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
        
        HealthChanged?.Invoke(_health.CurrentHealth,_health.MaxHealth);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}