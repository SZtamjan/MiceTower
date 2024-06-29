using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _Scripts.PlayerMovement
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [HideInInspector] public UnityEvent JumpEvent;
        
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                JumpEvent?.Invoke();
            }
        }
    }
}