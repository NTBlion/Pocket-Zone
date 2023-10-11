using System;

public class Health
{
    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; }
    
    public event Action<float, float> HealthChanged;
    
    public Health(float currentHealth)
    {
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 1f;
        }

        CurrentHealth = currentHealth;
        MaxHealth = CurrentHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        HealthChanged?.Invoke(CurrentHealth, MaxHealth);
    }
}