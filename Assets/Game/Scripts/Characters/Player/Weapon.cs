using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private Transform _bulletPoint;
    [SerializeField] [Min(1f)] private float _speed;

    public void Shot()
    {
        Instantiate(_bulletTemplate, _bulletPoint.position, _bulletPoint.rotation).Init(_bulletPoint.right * _speed);
    }
}