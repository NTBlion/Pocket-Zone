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
    }

    public void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }
}