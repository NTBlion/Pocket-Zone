using UnityEngine;

public class HasTargetState : State
{
    private readonly PlayerMovement _movement;
    private readonly PlayerRotation _rotation;
    private readonly WeaponRotation _weaponRotation;
    private readonly Enemy _enemy;


    public HasTargetState(PlayerMovement movement, PlayerRotation rotation, WeaponRotation weaponRotation, Enemy enemy)
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
        _rotation.Rotate(_enemy);
        _weaponRotation.Rotate(_enemy);
    }
}