using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivePauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
  
    
    void Start()
    {
        
//        pauseMenu.SetActive(false);
        
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
       
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    
    
    
    
    
}
