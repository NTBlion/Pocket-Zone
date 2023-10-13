using System;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    
    private Player _player;
    private JoystickMovement _joystick;

    
    private bool _isFacingRight = true;
    
    public void Init(JoystickMovement joystick)
    {
        _joystick = joystick;
    }
    
    public void Rotate()
    {
        var joystickVector = _joystick.ReturnVectorDirection();

        if (joystickVector.x > 0 && !_isFacingRight || joystickVector.x < 0 && _isFacingRight)
            Flip();
    }

    public void Rotate(CharacterHealth enemy)
    {
        if (enemy.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            _isFacingRight = true;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            _isFacingRight = false;
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0, 180, 0);
    }
}