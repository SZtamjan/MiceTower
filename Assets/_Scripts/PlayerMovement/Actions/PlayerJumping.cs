using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.PlayerMovement
{
    public class PlayerJumping : MonoBehaviour
    {
        [HideInInspector] public bool onGround = true;
        private Rigidbody2D _rigidbody2D;
     //   private Animator animator;
   
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            // animator = GetComponent<Animator>();
        }
        
        
        
        

        public void Jump(float height)
        {
            if (onGround)
            {
                
                _rigidbody2D.AddForce(Vector2.up * height * 50f);
            //  animator.SetBool("isJumping", !onGround);
            }
        }
    }
}