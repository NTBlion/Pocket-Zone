using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] [Min(0f)] private float _delayBeforeDestroy;
    [SerializeField] [Min(1f)] private float _damage;

    private WaitForSeconds _delay;

    public void Init(Vector2 velocity)
    {
        _rigidbody.velocity = velocity;
        _delay = new WaitForSeconds(_delayBeforeDestroy);
        StartCoroutine(DestroyBullet());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamagable idamagable))
        {
            idamagable.TakeDamage(_damage);
            DestroyBulletNow();
        }
    }

    private IEnumerator DestroyBullet()
    {
        yield return _delay;
        Destroy(gameObject);
    }

    private void DestroyBulletNow()
    {
        Destroy(gameObject);
    }
}