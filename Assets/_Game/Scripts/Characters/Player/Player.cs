using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] [Min(1f)] private float _speed;

    private JoystickMovement _joystick;
    private Detector _detector;
    private PlayerMovement _movement;
    private PlayerRotation _rotation;
    private WeaponRotation _weaponRotation;
    private CharacterHealth _enemy;

    private StateMachine _stateMachine;
    private PlayerRunState _playerRunState;

    public void Init(JoystickMovement joystick, Detector detector, PlayerMovement playerMovement,
        PlayerRotation rotation, WeaponRotation weaponRotation)
    {
        _joystick = joystick;
        _detector = detector;
        _movement = playerMovement;
        _rotation = rotation;
        _weaponRotation = weaponRotation;
        _stateMachine = new StateMachine();
        _stateMachine.Init(new PlayerIdleState());
        _playerRunState = new PlayerRunState(_movement, _rotation, _weaponRotation);
    }

    private void Update()
    {
        _stateMachine.CurrentState.FixedUpdate();
        _stateMachine.CurrentState.Update();

        var joystickVector = _joystick.ReturnVectorDirection();

        if (joystickVector != Vector2.zero)
        {
            _stateMachine.ChangeState(_playerRunState);
        }

        _enemy = _detector.FindNearestEnemy();

        if (_enemy != null)
            _stateMachine.ChangeState(new PlayerTargetState(_movement, _rotation, _weaponRotation, _enemy));
    }
}