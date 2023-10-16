using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private Transform _bulletPoint;
    [SerializeField] [Min(1f)] private float _speed;
    [SerializeField] [Min(1)] private int _bulletCount = 20;

    public Action<int> Shot;

    public void Shoot()
    {
        if (_bulletCount > 0)
        {
            Instantiate(_bulletTemplate, _bulletPoint.position, _bulletPoint.rotation)
                .Init(_bulletPoint.right * _speed);

            _bulletCount--;
            Shot?.Invoke(_bulletCount);
        }
    }
}