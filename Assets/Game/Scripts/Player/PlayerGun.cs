using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private Transform _bulletPoint;
    [SerializeField] private float _speed;

    public void Shot()
    {
        Instantiate(_bulletTemplate, _bulletPoint.position, _bulletPoint.rotation).Init(_bulletPoint.right * _speed);
    }
    public void Shot(Vector2 direction)
    {
        Instantiate(_bulletTemplate, _bulletPoint.position, _bulletPoint.rotation).Init(direction * _speed);
    }
}