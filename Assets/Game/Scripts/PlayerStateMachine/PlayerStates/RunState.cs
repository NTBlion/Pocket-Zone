using UnityEngine;

public class RunState : State
{
    private readonly PlayerMovement _movement;
    private readonly PlayerRotation _rotation;

    private float _speed;

    public RunState(PlayerMovement movement, PlayerRotation rotation)
    {
        _movement = movement;
        _rotation = rotation;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        _movement.Move();
        _rotation.Rotate();
        Debug.Log("Я в райн стейте");
    }
}