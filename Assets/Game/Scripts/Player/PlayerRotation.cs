using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private JoystickMovement _joystick;

    public void Init(JoystickMovement joystick)
    {
        _joystick = joystick;
    }

    private void Update()
    {
        var rotation = _joystick.ReturnVectorDirection();
        if (rotation.x < 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        if (rotation.x > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}
