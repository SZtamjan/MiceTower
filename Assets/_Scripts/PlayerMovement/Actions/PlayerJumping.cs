using _Scripts.Audio;
using UnityEngine;

namespace _Scripts.PlayerMovement.Actions
{
    public class PlayerJumping : MonoBehaviour
    {
        [HideInInspector] public bool onGround = true;
        private Rigidbody2D _rigidbody2D;
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            // animator = GetComponent<Animator>();
        }
        
        
        
        

        public void Jump(float height)
        {
            if (onGround)
            {
                AudioManagerScript.Instance.PlaySFXOneShot("Jump");
                _rigidbody2D.AddForce(Vector2.up * height * 50f);
            //  animator.SetBool("isJumping", !onGround);
            }
        }
    }
}