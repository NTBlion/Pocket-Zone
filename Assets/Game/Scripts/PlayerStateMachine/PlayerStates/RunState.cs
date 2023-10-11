using UnityEngine;

public class RunState : State
{
    private readonly Rigidbody2D _rigidbody;
    
    private Player _player;
    private JoystickMovement _joystick;

    private float _speed;
    
    public RunState(Player player, JoystickMovement joystick, Rigidbody2D rigidbody2D, float speed)
    {
        _player = player;
        _joystick = joystick;
        _rigidbody = rigidbody2D;
        _speed = speed;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Я вошёл");
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Move();
    }

    private void Move()
    {
        _rigidbody.MovePosition(_rigidbody.position + _joystick.ReturnVectorDirection() * (_speed * Time.fixedDeltaTime));
    }
}
