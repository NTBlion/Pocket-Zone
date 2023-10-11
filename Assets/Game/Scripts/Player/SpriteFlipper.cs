using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    private Player _player;
    private JoystickMovement _joystick;

    private bool _isFacingRight = true;

    public void Init(Player player, JoystickMovement joystick)
    {
        _player = player;
        _joystick = joystick;
    }

    private void Update()
    {
        var joystickVector = _joystick.ReturnVectorDirection();

        if (joystickVector.x > 0 && !_isFacingRight || joystickVector.x < 0 && _isFacingRight)
            Flip();
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        _player.transform.Rotate(0, 180, 0);
    }
}