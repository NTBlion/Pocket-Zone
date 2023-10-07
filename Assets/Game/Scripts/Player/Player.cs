using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    private Checker _checker;
    private PlayerGun _playerGun;
    
    public void Init(Checker checker)
    {
        _checker = checker;
        _checker.Founded += OnFounded;
    }

    public void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }

    private void OnDisable()
    {
        _checker.Founded -= OnFounded;
    }

    private void OnFounded(Collider2D obj)
    {
        Debug.Log("Я тебя нашёл пидр" + obj.name);
    }
}