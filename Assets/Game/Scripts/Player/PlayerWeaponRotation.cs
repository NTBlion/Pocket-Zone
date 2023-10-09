using System;
using UnityEngine;

public class PlayerWeaponRotation : MonoBehaviour
{
    private float _rotationZ;
    private JoystickMovement _joystick;

    public void Init(JoystickMovement joystick)
    {
        _joystick = joystick;
    }

    private void Update()
    {
        var joystickRotation = _joystick.ReturnVectorDirection();
        _rotationZ = Mathf.Atan2(joystickRotation.y, joystickRotation.x) *
                    Mathf.Rad2Deg;

        if (joystickRotation.x < 0)
        {
            transform.localRotation = Quaternion.Euler(180,180,-_rotationZ);
        }
        if (joystickRotation.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0,0,_rotationZ);
        }
    }
}