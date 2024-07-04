using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Menu
{
    public class ActivePauseMenu : MonoBehaviour
    {
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
}