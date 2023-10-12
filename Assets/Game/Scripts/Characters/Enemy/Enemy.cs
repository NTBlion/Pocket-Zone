using UnityEngine;

public class Enemy : MonoBehaviour
{
    private CharacterHealth _player;
    private EnemyMovement _movement;
    private Detector _detector;

    private StateMachine _stateMachine;
    
    public void Init(CharacterHealth player, EnemyMovement movement, Detector detector)
    {
        _player = player;
        _movement = movement;
        _detector = detector;
        _stateMachine = new StateMachine();
        _stateMachine.Init(new EnemyIdleState());
    }
    
}