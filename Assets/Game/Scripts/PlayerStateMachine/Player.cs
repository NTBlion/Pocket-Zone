using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineA
{
    public class Player : MonoBehaviour
    {
        private StateMachine _stateMachine;
        private JoystickMovement _joystick;

        public void Init(Joy)
        {
            _stateMachine = new StateMachine();
            _stateMachine.Init(new IdleState());
        }
    }
}

