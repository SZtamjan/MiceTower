using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void Exit()
        {
            Debug.Log("Exit");
            Application.Quit();
        } 
    }
}
