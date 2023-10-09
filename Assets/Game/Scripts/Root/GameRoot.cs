using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private JoystickMovement _joystick;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private CameraFollow _camera;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerRotation _rotation;
    [SerializeField] private PlayerWeaponRotation _weaponRotation;

    private void Awake()
    {
        _camera.Init(_player);
        _movement.Init(_joystick);
        _rotation.Init(_joystick);
        _weaponRotation.Init(_joystick);
    }
}