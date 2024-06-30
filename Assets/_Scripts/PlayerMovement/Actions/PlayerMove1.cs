/* using System;
using UnityEngine;

namespace _Scripts.PlayerMovement.Actions
{
    public class PlayerMove : MonoBehaviour
    {
        private float playerAcceleration = 1f;
        private float maxSpeed = 1f;
        private float myDirection = 0f;

        private Rigidbody2D _rigidbody2D;
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            maxSpeed = GetComponent<PlayerController>().MaxPlayerSpeed;
            playerAcceleration = GetComponent<PlayerController>().PlayerAcceleration;
        }
        
        public void ChangeDirection(float dir)
        {
            myDirection = dir;
        }

        private void Update()
        {
            _rigidbody2D.AddForce(myDirection * playerAcceleration * 10f * Vector2.right);
            
            Vector2 currVelocity = _rigidbody2D.velocity;
            float newXVel = Mathf.Clamp(currVelocity.x, -maxSpeed, maxSpeed);
            currVelocity.x = newXVel;
            _rigidbody2D.velocity = currVelocity;
        }
        
    }
}

*/