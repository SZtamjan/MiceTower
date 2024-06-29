using System;
using _Scripts.PlayerMovement.Actions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _Scripts.PlayerMovement.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [HideInInspector] public UnityEvent JumpEvent;

        private PlayerMove _playerMove;

        private void Start()
        {
            _playerMove = GetComponent<PlayerMove>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                JumpEvent?.Invoke();
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            float readValue = context.ReadValue<float>();
            if (readValue > 0 && context.started)
            {
                _playerMove.ChangeDirection(readValue);
            }
            else if (readValue < 0 && context.started)
            {
                _playerMove.ChangeDirection(readValue);
            }
            else if(readValue == 0 && context.canceled)
            {
                _playerMove.ChangeDirection(readValue);
            }
        }
    }
}