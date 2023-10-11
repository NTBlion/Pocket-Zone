using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    private JoystickMovement _joystick;

    public void Init(JoystickMovement joystick)
    {
        _joystick = joystick;
    }

    private void Update()
    {
        Vector2 joystickVector = _joystick.ReturnVectorDirection();
        float angle = CalculateAngle(joystickVector);

        switch (joystickVector.x)
        {
            case > 0:
                transform.eulerAngles = new Vector3(transform.rotation.x, transform.localRotation.y, angle);
                break;
            case < 0:
                transform.eulerAngles = new Vector3(180, 0, -angle);
                break;
        }
    }

    private float CalculateAngle(Vector2 joystickVector)
    {
        return Mathf.Atan2(joystickVector.y, joystickVector.x) * Mathf.Rad2Deg;
    }
}

public static class Utilities 
{
    public static float CalculateAngle1(Vector2 vector)
    {
        return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
    }
}