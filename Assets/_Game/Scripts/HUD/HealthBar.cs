using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private CharacterHealth _health;
    [SerializeField] private Slider _fill;

    private void Update()
    {
        _fill.transform.rotation = quaternion.identity;
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float currentHealth, float maxHealth)
    {
        _fill.value = currentHealth / maxHealth;
    }
}