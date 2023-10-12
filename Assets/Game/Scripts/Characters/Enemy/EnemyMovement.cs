using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    
    public void Move(CharacterHealth player)
    {
        _rigidbody.velocity = (player.transform.position - transform.position) * _speed;
    }
}