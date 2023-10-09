using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private StateMachine _stateMachine;
    private JoystickMovement _joystick;

    public void Init(JoystickMovement _joystick)
    {
        _stateMachine = new StateMachine();
        _stateMachine.Init(new IdleState());
    }
}