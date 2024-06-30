using System;
using _Scripts.CoreSystems;
using _Scripts.PlayerMovement.Actions;
using _Scripts.PlayerMovement.Input;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.PlayerMovement
{
    public class PlayerController : MonoBehaviour
    {
        #region Components

        private PlayerInputHandler _playerInputHandler;
        private PlayerJumping _playerJumping;

        #endregion

        [SerializeField] private float playerAcceleration = 1f;
        [SerializeField] private float maxMaxPlayerSpeed = 1f;
        [SerializeField] private float jumpHeight = 1f;

        private Vector2 _bottomBound;
        
        public float JumpHeight => jumpHeight;

        public float PlayerAcceleration => playerAcceleration;
        public float MaxPlayerSpeed => maxMaxPlayerSpeed;
        
        private void Start()
        {
            _bottomBound = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
            _playerInputHandler = GetComponent<PlayerInputHandler>();
            _playerJumping = GetComponent<PlayerJumping>();
            
            _playerInputHandler.JumpEvent.AddListener(() => _playerJumping.Jump(jumpHeight));
        }

        private void Update()
        {
            if (transform.position.y < _bottomBound.y && GameManager.Instance.CurrentGameState != GameState.Lose)
            {
                GameManager.Instance.StartNewGameState(GameState.Lose);
            }
        }
    }
}