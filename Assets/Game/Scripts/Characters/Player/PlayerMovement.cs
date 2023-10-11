using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] [Min(1f)] private float _speed;

    private JoystickMovement _joystick;

    public void Init(JoystickMovement joystick)
    {
        _joystick = joystick;
    }

    public void Move()
    {
        _rigidbody.MovePosition(
            _rigidbody.position + _joystick.ReturnVectorDirection() * (_speed * Time.fixedDeltaTime));
    }
}