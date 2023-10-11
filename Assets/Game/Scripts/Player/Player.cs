using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private JoystickMovement _joystick;
    private EnemyDetector _detector;
    private PlayerMovement _movement;
    private PlayerRotation _rotation;

    private Enemy _enemy;

    private StateMachine _stateMachine;
    private RunState _runState;

    public void Init(JoystickMovement joystick, EnemyDetector detector, PlayerMovement playerMovement,
        PlayerRotation rotation)
    {
        _joystick = joystick;
        _detector = detector;
        _movement = playerMovement;
        _rotation = rotation;
        _stateMachine = new StateMachine();
        _stateMachine.Init(new IdleState());
        _runState = new RunState(_movement, _rotation);
    }

    private void Update()
    {
        _stateMachine.CurrentState.FixedUpdate();

        var joystickVector = _joystick.ReturnVectorDirection();

        if (joystickVector != Vector2.zero)
        {
            _stateMachine.ChangeState(_runState);
        }

        if (_detector.FindNearestEnemy() != null)
        {
            _enemy = _detector.FindNearestEnemy();
            _stateMachine.ChangeState(new HasTargetState(_movement, _detector, _rotation, _enemy));
        }
    }
}