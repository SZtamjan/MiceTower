using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] public int sceneIndex;
        
        
        public void Play()
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void Exit()
        {
            Debug.Log("Exit");
            Application.Quit();
        } 
    }
}
