using System;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private JoystickMovement _joystick;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private CameraFollow _camera;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _camera.Init(_player);
        _movement.Init(_joystick);
    }

    private void Update()
    {
        _movement.Move();
    }
}