using UnityEngine;

public class JoystickMovement : JoystickHandler
{
    public Vector2 ReturnVectorDirection()
    {
        if (InputVector.x != 0 || InputVector.y != 0)
            return new Vector2(InputVector.x, InputVector.y);

        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}