using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _delayBeforeDestroy;

    private WaitForSeconds _delay;
    public void Init(Vector2 velocity)
    {
        _rigidbody.velocity = velocity;
        _delay = new WaitForSeconds(_delayBeforeDestroy);
        StartCoroutine(DestroyBullet());
    }

    private IEnumerator DestroyBullet()
    {
        yield return _delay;
        Destroy(gameObject);
    }
}