using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CameraFollow _camera;
    [SerializeField] private JoystickMovement _joystick;
    [SerializeField] private SpriteFlipper _spriteFlipper;
    [SerializeField] private WeaponRotation _weaponRotation;

    private void Awake()
    {
        _player.Init(_joystick);
        _camera.Init(_player);
        _spriteFlipper.Init(_player,_joystick);
        _weaponRotation.Init(_joystick);
    }
}