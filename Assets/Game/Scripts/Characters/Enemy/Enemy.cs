using UnityEngine;

public class Enemy : MonoBehaviour
{
    private CharacterHealth _player;
    private EnemyMovement _movement;
    private Detector _detector;

    private StateMachine _stateMachine;

    public void Init(EnemyMovement movement, Detector detector)
    {
        _movement = movement;
        _detector = detector;
        _stateMachine = new StateMachine();
        _stateMachine.Init(new EnemyIdleState());
    }


    private void Update()
    {
        _stateMachine.CurrentState.Update();
        _stateMachine.CurrentState.FixedUpdate();

        if (_detector.FindNearestEnemy() != null)
        {
            _player = _detector.FindNearestEnemy();
            _stateMachine.ChangeState(new EnemyTargetState(_player, _movement));
        }
    }
}