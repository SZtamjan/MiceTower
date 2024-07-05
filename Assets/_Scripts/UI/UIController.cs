using System;
using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class UIController : MonoBehaviour
    {
        public static UIController Instance;
        
        [SerializeField] private GameObject gameWinCanvas;
        [SerializeField] private GameObject gameOverCanvas;
        [SerializeField] private TextMeshProUGUI scoreText;
        
        private void Awake()
        {
            Instance = this;
        }
        
        public void NewScoreToDisplay(int newScore)
        {
            scoreText.text = "Score: " + newScore;
        }

        public void WinUI()
        {
            gameWinCanvas.SetActive(true);
        }

        public void LoseUI()
        {
            gameOverCanvas.SetActive(true);
        }
    }
}