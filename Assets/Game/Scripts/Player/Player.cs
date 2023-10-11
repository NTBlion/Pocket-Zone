using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Rigidbody2D _rigidbody;

    private StateMachine _stateMachine;
    private JoystickMovement _joystick;
    private RunState _runState;

    public void Init(JoystickMovement joystick)
    {
        _joystick = joystick;
        _stateMachine = new StateMachine();
        _stateMachine.Init(new IdleState());
        _runState = new RunState(this, _joystick, _rigidbody, _speed);
    }

    private void Update()
    {
        _stateMachine.CurrentState.FixedUpdate();

        var joystickVector = _joystick.ReturnVectorDirection();

        if (joystickVector != Vector2.zero)
        {
            _stateMachine.ChangeState(_runState);
        }
    }
}