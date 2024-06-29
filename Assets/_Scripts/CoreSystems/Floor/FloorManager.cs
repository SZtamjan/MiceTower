using System.Collections;
using UnityEngine;

namespace _Scripts.CoreSystems.Floor
{
    public class FloorManager : MonoBehaviour
    {
        [SerializeField] private GameObject floorPrefab;

        public IEnumerator SpawnFloors(float spawnRate, float floorSpeed)
        {
            Camera cam = Camera.main;
            Vector2 leftBound = cam.ViewportToWorldPoint(new Vector2(0f, 1f));
            Vector2 rightBound = cam.ViewportToWorldPoint(new Vector2(1f, 1f));

            leftBound.y += 5f;
            rightBound.y += 5f;

            while (true)
            {
                Vector3 spawnPos = new Vector3(Random.Range(leftBound.x, rightBound.x), rightBound.y, 0f);
                GameObject currFloor = Instantiate(floorPrefab, spawnPos, Quaternion.identity);
                currFloor.GetComponent<Floor>().mySpeed = floorSpeed;

                yield return new WaitForSeconds(spawnRate);
            }

            yield return null;
        }
    }
}