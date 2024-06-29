using System;
using _Scripts.CoreSystems.Floor;
using _Scripts.Walls;
using UnityEngine;

namespace _Scripts.CoreSystems
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        private GameState currentGameState;
        private Coroutine _floorSpawnCor;
        
        [Header("Level settings")]
        [SerializeField] private int goalScore = 0;
        [Tooltip("Time between spawn")] [SerializeField] private float spawnFloorRate = 1f;
        [SerializeField] private float floorMoveSpeed = 5f;
        
        public GameState CurrentGameState => currentGameState;

        public int GoalScore => goalScore;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            StartNewGameState(GameState.PreStart);
        }

        public void StartNewGameState(GameState newState)
        {
            currentGameState = newState;
            Debug.Log("Curr state " + newState);
            
            switch (newState)
            {
                case GameState.PreStart:
                    SetupWalls();
                    StartNewGameState(GameState.Game);
                    break;
                case GameState.Game:
                    StartFloor();
                    break;
                case GameState.Finish:
                    StopFloor();
                    SpawnFinalRoom();
                    break;
                case GameState.Win:
                    Debug.Log("Win is To be implemented");
                    break;
                case GameState.Lose:
                    Debug.Log("Lose is To be implemented");
                    break;
                default:
                    Debug.LogError("Terrible exception, cant be " + newState);
                    break;
            }
        }

        #region PreStart

        private void SetupWalls()
        {
            if (!TryGetComponent(out WallsSetup wallsSetup))
            {
                Debug.LogError("Brak skryptu WallsSetup w obiekcie GameManager");
                return;
            }

            wallsSetup.SetupMyWalls();
        }

        #endregion

        #region Game

        private void StartFloor()
        {
            if (!TryGetComponent(out FloorManager floorManager))
            {
                Debug.LogError("Brak FloorManager w obiekcie GameManager");
                return;
            }

            _floorSpawnCor = StartCoroutine(floorManager.SpawnFloors(spawnFloorRate, floorMoveSpeed));
        }

        #endregion

        #region Finish

        private void StopFloor()
        {
            if (_floorSpawnCor != null)
            {
                StopCoroutine(_floorSpawnCor);
                _floorSpawnCor = null;
            }
        }

        private void SpawnFinalRoom()
        {
            if (!TryGetComponent(out FloorManager floorManager))
            {
                Debug.LogError("Brak FloorManager w obiekcie GameManager");
                return;
            }
            
            floorManager.SpawnRoom(floorMoveSpeed);
        }

        #endregion
        
    }

    public enum GameState
    {
        PreStart,
        Game,
        Finish,
        Win,
        Lose
    }
}