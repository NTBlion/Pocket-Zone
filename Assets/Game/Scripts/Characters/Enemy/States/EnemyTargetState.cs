public class EnemyTargetState : State
{
    private CharacterHealth _player;
    private readonly EnemyMovement _movement;

    public EnemyTargetState(CharacterHealth player, EnemyMovement movement)
    {
        _player = player;
        _movement = movement;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        _movement.Move(_player);
    }
}