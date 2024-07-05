using System;
using System.Collections;
using _Scripts.CoreSystems;
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
        private GameManager _gameManager;

        private void Start()
        {
            _playerMove = GetComponent<PlayerMove>();
            _gameManager = GameManager.Instance;
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started && _gameManager.CurrentGameState != GameState.Lose && _gameManager.CurrentGameState != GameState.Win)
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
            else if (readValue == 0 && context.canceled)
            {
                _playerMove.ChangeDirection(readValue);
            }
        }

    }
}