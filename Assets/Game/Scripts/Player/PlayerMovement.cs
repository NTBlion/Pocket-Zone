using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;

    private JoystickMovement _joystick;

    public void Init(JoystickMovement joystick)
    {
        _joystick = joystick;
    }
    
    public void Move()
    {
        _rigidbody.MovePosition(_rigidbody.position + _joystick.ReturnVectorDirection() * (_speed * Time.fixedDeltaTime));
    }
}
