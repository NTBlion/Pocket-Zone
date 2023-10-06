using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;

    private JoystickMovement _joystick;
    private Vector2 _direction;
    
    public void Init(JoystickMovement joystick)
    {
        _joystick = joystick;
    }

    private void Update()
    {
        _direction = _joystick.ReturnVectorDirection();
    }

    public void Move()
    {
        _rigidbody.MovePosition(_rigidbody.position + _direction * (_speed * Time.fixedDeltaTime));
    }
}
