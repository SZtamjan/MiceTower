using System;
using _Scripts.UI;
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
            UIController.Instance.NewScoreToDisplay(_points);
        }

        private void CheckIfFinish()
        {
            GameManager gm = GetComponent<GameManager>();
            if (gm.GoalScore <= _points && GameManager.Instance.CurrentGameState == GameState.Game) GetComponent<GameManager>().StartNewGameState(GameState.Finish);
        }
    }
}