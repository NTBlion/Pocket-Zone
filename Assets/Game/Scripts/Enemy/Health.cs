using System;

public class Health
{
    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; }

    public event Action<float, float> HealthChanged;

    public Health(float currentHealth, float maxHealth)
    {
        CurrentHealth = currentHealth;
        MaxHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        HealthChanged?.Invoke(CurrentHealth, MaxHealth);
    }
}