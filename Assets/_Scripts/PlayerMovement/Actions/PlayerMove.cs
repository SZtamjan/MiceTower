using System;
using UnityEngine;

namespace _Scripts.PlayerMovement.Actions
{
    public class PlayerMove : MonoBehaviour
    {
        private float playerAcceleration = 1f;
        private float maxSpeed = 1f;
        private float myDirection = 0f;
        [SerializeField] private bool isGyro = false;
        private Rigidbody2D _rigidbody2D;
        

        private void Start()
        {
            UnityEngine.Input.gyro.enabled = isGyro;
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
            if (isGyro)
            { 
                Quaternion phoneRot = UnityEngine.Input.gyro.attitude;
                phoneRot = Quaternion.Euler(phoneRot.eulerAngles.x,phoneRot.eulerAngles.y,phoneRot.eulerAngles.z - 90f);

                float normalizedValue = Mathf.Clamp(phoneRot.eulerAngles.z / 360.0f, -1.0f, 1.0f);
                
                if (normalizedValue > 0f && normalizedValue < .5f)
                {
                    _rigidbody2D.AddForce(normalizedValue * -4f * playerAcceleration * 10f * Vector2.right);
                    Debug.Log("Normalized Z Rotation: " + normalizedValue);
                    
                    Vector2 currVelocity = _rigidbody2D.velocity;
                    float newXVel = Mathf.Clamp(currVelocity.x, -maxSpeed, maxSpeed);
                    currVelocity.x = newXVel;
                    _rigidbody2D.velocity = currVelocity;
                    
                }
                else if (normalizedValue < 1f && normalizedValue > .5f)
                {
                    float invertedNormalizedValue = 1f - normalizedValue;
                    _rigidbody2D.AddForce(invertedNormalizedValue * 4f * playerAcceleration * 10f * Vector2.right);
                    Debug.Log("Inverted Z Rotation: " + invertedNormalizedValue);

                    Vector2 currVelocity = _rigidbody2D.velocity;
                    float newXVel = Mathf.Clamp(currVelocity.x, -maxSpeed, maxSpeed);
                    currVelocity.x = newXVel;
                    _rigidbody2D.velocity = currVelocity;
                    
                }
                
            }
            else
            {
                _rigidbody2D.AddForce(myDirection * playerAcceleration * 10f * Vector2.right);

                Vector2 currVelocity = _rigidbody2D.velocity;
                float newXVel = Mathf.Clamp(currVelocity.x, -maxSpeed, maxSpeed);
                currVelocity.x = newXVel;
                _rigidbody2D.velocity = currVelocity;
                
            }
        }
    }
}