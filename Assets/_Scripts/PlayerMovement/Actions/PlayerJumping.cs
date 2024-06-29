using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.PlayerMovement
{
    public class PlayerJumping : MonoBehaviour
    {
        public bool onGround = true;
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Jump(float height)
        {
            if (onGround)
            {
                _rigidbody2D.AddForce(Vector2.up * height * 50f);
            }
        }
    }
}