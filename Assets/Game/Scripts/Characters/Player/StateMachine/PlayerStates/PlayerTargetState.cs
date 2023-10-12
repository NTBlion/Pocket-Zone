using UnityEngine;

public class PlayerTargetState : State
{
    private readonly PlayerMovement _movement;
    private readonly PlayerRotation _rotation;
    private readonly WeaponRotation _weaponRotation;
    private readonly CharacterHealth _enemy;

    public PlayerTargetState(PlayerMovement movement, PlayerRotation rotation, WeaponRotation weaponRotation, CharacterHealth enemy)
    {
        _movement = movement;
        _rotation = rotation;
        _weaponRotation = weaponRotation;
        _enemy = enemy;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        _movement.Move();
    }

    public override void Update()
    {
        if (_enemy != null)
        {
            _rotation.Rotate(_enemy);
            _weaponRotation.Rotate(_enemy);
        }
    }
}