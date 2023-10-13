using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    private JoystickMovement _joystick;

    public void Init(JoystickMovement joystick)
    {
        _joystick = joystick;
    }

    public void Rotate()
    {
        var joystickVector = _joystick.ReturnVectorDirection();

        float angle = CalculateAngle(joystickVector);

        switch (joystickVector.x)
        {
            case > 0:
                transform.eulerAngles = new Vector3(transform.localRotation.x, transform.localRotation.y, angle);
                break;
            case < 0:
                transform.eulerAngles = new Vector3(180, 0, -angle);
                break;
        }
    }

    public void Rotate(CharacterHealth enemy)
    {
        var direction = transform.position - enemy.transform.position;
        
        float angle = CalculateAngle(direction);
        
        switch (direction.x)
        {
            case > 0:
                transform.eulerAngles = new Vector3(transform.localRotation.x, 180, -angle);
                break;
            case < 0:
                transform.eulerAngles = new Vector3(180, 180, angle);
                break;
        }
    }

    private float CalculateAngle(Vector2 vector2)
    {
        return Mathf.Atan2(vector2.y, vector2.x) * Mathf.Rad2Deg;
    }
}