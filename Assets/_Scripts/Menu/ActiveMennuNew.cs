using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ActiveMennuNew : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public void PauseActive(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SwitchPause();
        }
    }
    private void SwitchPause()
    { 
        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            return;
        }
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
         
    }
}
