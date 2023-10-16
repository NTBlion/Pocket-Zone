using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Detector _detector;
    [SerializeField] private EnemyMovement _movement;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRange = 0.1f;
    [SerializeField] private float _delayBeforeAttack = 1f;

    private CharacterHealth _player;
    private float _timer;

    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;

        _player = _detector.FindNearestEnemy();

        if (_player == null) return;
        _movement.Move(_player);

        if (Vector2.Distance(transform.position, _player.transform.position) < _attackRange &&
            _timer > _delayBeforeAttack)
        {
            _player.TakeDamage(_damage);
            _timer = 0;
        }
    }
}