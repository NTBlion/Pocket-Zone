using System;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private JoystickMovement _joystick;
    [SerializeField] private PlayerMovement _movement;

    private void Awake()
    {
        _movement.Init(_joystick);
    }

    private void Update()
    {
        _movement.Move();
    }
}