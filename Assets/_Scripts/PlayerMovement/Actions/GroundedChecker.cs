using System;
using UnityEngine;

namespace _Scripts.PlayerMovement.Actions
{
    public class GroundedChecker : MonoBehaviour
    {
        public static GroundedChecker Instance;
        
        [SerializeField] private PlayerJumping playerJumping;
        public LayerMask layerMask;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 0.5f, layerMask);

            if (cols.Length > 0)
            {
                playerJumping.onGround = true;
            }
            else if (cols.Length == 0)
            {
                playerJumping.onGround = false;
            }
        }

        private void CheckIfVarsAreNull()
        {
            if (playerJumping == null)
            {
                Debug.LogError("PlayerJumping nie podpiety do GroundChecker");
                return;
            }
        }
    }
}