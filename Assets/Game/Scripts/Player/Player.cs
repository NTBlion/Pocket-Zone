using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    private Checker _checker;
    private PlayerWeapon _playerWeapon;
    private PlayerWeapon _weapon;

    private Vector2 _direction;
    
    public void Init(Checker checker, PlayerWeapon weapon)
    {
        _checker = checker;
        _weapon = weapon;
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
        Enemy enemy = obj.GetComponent<Enemy>();

        _direction =enemy.transform.position - transform.position;
        
        _weapon.Shot(_direction);
    }
}