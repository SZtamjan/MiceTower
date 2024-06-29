using System;
using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class UIController : MonoBehaviour
    {
        public static UIController Instance;
        
        [SerializeField] private TextMeshProUGUI scoreText;
        
        private void Awake()
        {
            Instance = this;
        }
        
        public void NewScoreToDisplay(int newScore)
        {
            scoreText.text = "Score: " + newScore;
        }
    }
}