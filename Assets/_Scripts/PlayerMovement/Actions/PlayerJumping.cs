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