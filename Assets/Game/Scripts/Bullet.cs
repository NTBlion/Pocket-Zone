using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    
    public void Init(Vector2 velocity)
    {
        _rigidbody.velocity = velocity;
    }
}