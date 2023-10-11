using UnityEngine;

public class HasTargetState : State
{
    private readonly PlayerMovement _movement;
    private readonly EnemyDetector _detector;
    private readonly PlayerRotation _rotation;

    private Enemy _enemy;

    public HasTargetState(PlayerMovement movement, EnemyDetector detector, PlayerRotation rotation, Enemy enemy)
    {
        _movement = movement;
        _detector = detector;
        _rotation = rotation;
        _enemy = enemy;
    }
    
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        _movement.Move();
        _rotation.Rotate(_enemy);
    }
}