using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;

    public void Move(CharacterHealth player)
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        _rigidbody.MovePosition(_rigidbody.position + direction * (Time.fixedDeltaTime * _speed));
    }
}