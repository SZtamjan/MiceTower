using UnityEngine;

namespace _Scripts.Walls
{
    public class WallsSetup : MonoBehaviour
    {
        [SerializeField] private Transform leftWall;
        [SerializeField] private Transform rightWall;
        [SerializeField] private Transform celling;

        public void SetupMyWalls()
        {
            if (leftWall == null || rightWall == null)
            {
                Debug.LogError("Sciany nie sa podpiete w WallSetup w obiekcie GameManager");
                return;
            }
            
            Camera cam = Camera.main;
            Vector2 leftBound = cam.ViewportToWorldPoint(new Vector2(0, .5f));
            Vector2 rightBound = cam.ViewportToWorldPoint(new Vector2(1, .5f));
            Vector2 topBound = cam.ViewportToWorldPoint(new Vector2(.5f, 1f));

            leftWall.position = leftBound;
            rightWall.position = rightBound;
            celling.position = topBound;
        }
    }
}