using System;
using UnityEngine;

namespace _Scripts.CoreSystems
{
    public class Points : MonoBehaviour
    {
        public static Points Instance;

        private int _points = 0;

        public int AddPoints
        {
            set
            {
                _points += value;
                UpdateUI();
                CheckIfFinish();
            }
        }

        private void Awake()
        {
            Instance = this;
        }

        private void UpdateUI()
        {
            
        }

        private void CheckIfFinish()
        {
            GameManager gm = GetComponent<GameManager>();
            if (gm.GoalScore <= _points) GetComponent<GameManager>().StartNewGameState(GameState.Finish);
        }
    }
}