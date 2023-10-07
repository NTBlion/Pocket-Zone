using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private JoystickMovement _joystick;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private CameraFollow _camera;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerRotation _playerRotation;
    [SerializeField] private Checker _checker;

    private void Awake()
    {
        _camera.Init(_player);
        _movement.Init(_joystick);
        _playerRotation.Init(_joystick);
        _player.Init(_checker);
    }
}