using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerWeaponRotation : MonoBehaviour
{
    private float _rotationZ;
    private bool _hasTarget;
    private JoystickMovement _joystick;
    [SerializeField] Enemy _enemy;

    public void Init(JoystickMovement joystick)
    {
        _joystick = joystick;
    }

    public void Init(Enemy enemy)
    {
        _enemy = enemy;
    }

    private void Update()
    {
        //ActivateJoystickRotation();

        if (_enemy != null)
        {
            var direction = (_enemy.transform.position - transform.position).normalized;
            var _rotationZ2 = Mathf.Atan2(direction.y, direction.x) *
                              Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, _rotationZ2);
        }
    }

    private void ActivateJoystickRotation()
    {
        var joystickRotation = _joystick.ReturnVectorDirection();
        _rotationZ = Mathf.Atan2(joystickRotation.y, joystickRotation.x) *
                     Mathf.Rad2Deg;

        if (joystickRotation.x < 0)
        {
            transform.localRotation = Quaternion.Euler(180, 180, -_rotationZ);
        }

        if (joystickRotation.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, _rotationZ);
        }
    }
}