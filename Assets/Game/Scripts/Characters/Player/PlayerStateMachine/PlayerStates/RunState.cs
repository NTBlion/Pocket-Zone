using UnityEngine;

public class RunState : State
{
    private readonly PlayerMovement _movement;
    private readonly PlayerRotation _rotation;
    private readonly WeaponRotation _weaponRotation;
        

    public RunState(PlayerMovement movement, PlayerRotation rotation, WeaponRotation weaponRotation)
    {
        _movement = movement;
        _rotation = rotation;
        _weaponRotation = weaponRotation;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        _movement.Move();
        _rotation.Rotate();
        _weaponRotation.Rotate();
    }
}