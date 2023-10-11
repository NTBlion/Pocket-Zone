using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] [Min(1f)] private float _speed;

    private JoystickMovement _joystick;
    private EnemyDetector _detector;
    private PlayerMovement _movement;
    private PlayerRotation _rotation;
    private WeaponRotation _weaponRotation;

    private Enemy _enemy;

    private StateMachine _stateMachine;
    private RunState _runState;

    public void Init(JoystickMovement joystick, EnemyDetector detector, PlayerMovement playerMovement,
        PlayerRotation rotation, WeaponRotation weaponRotation)
    {
        _joystick = joystick;
        _detector = detector;
        _movement = playerMovement;
        _rotation = rotation;
        _weaponRotation = weaponRotation;
        _stateMachine = new StateMachine();
        _stateMachine.Init(new IdleState());
        _runState = new RunState(_movement, _rotation, _weaponRotation);
    }

    private void Update()
    {
        _stateMachine.CurrentState.FixedUpdate();
        _stateMachine.CurrentState.Update();

        var joystickVector = _joystick.ReturnVectorDirection();

        if (joystickVector != Vector2.zero)
        {
            _stateMachine.ChangeState(_runState);
        }

        if (_detector.FindNearestEnemy() != null)
        {
            _stateMachine.CurrentState.Update();
            _enemy = _detector.FindNearestEnemy();
            _stateMachine.ChangeState(new HasTargetState(_movement, _rotation, _weaponRotation, _enemy));
        }
    }
}