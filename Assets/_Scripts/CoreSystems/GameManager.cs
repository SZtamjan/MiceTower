using UnityEngine;

namespace _Scripts.CoreSystems
{
    public class GameManager : MonoBehaviour
    {
        public GameState currentGameState;
        
        public void StartNewGameState(GameState newState)
        {
            switch (newState)
            {
                case GameState.PreStart:
                    currentGameState = GameState.PreStart;
                    //Do something
                    break;
                case GameState.Game:
                    currentGameState = GameState.Game;
                    //Do something
                    break;
                case GameState.Finish:
                    currentGameState = GameState.Finish;
                    //Do something
                    break;
                default:
                    Debug.Log("Terrible exception");
                    break;
            }
        }
        
        
    }

    public enum GameState
    {
        PreStart,
        Game,
        Finish
    }
}