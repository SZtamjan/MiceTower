using System;
using UnityEngine;

namespace _Scripts.PlayerMovement
{
    public class PlayerController : MonoBehaviour
    {
        #region Components

        private PlayerInputHandler _playerInputHandler;
        private PlayerJumping _playerJumping;

        #endregion
        
        [SerializeField] private float jumpHeight = 1f;

        private void Start()
        {
            _playerInputHandler = GetComponent<PlayerInputHandler>();
            _playerJumping = GetComponent<PlayerJumping>();
            
            _playerInputHandler.JumpEvent.AddListener(() => _playerJumping.Jump(jumpHeight));
        }
    }
}