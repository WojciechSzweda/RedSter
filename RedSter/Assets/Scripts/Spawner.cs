using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject platformPrefab;
    public GameObject mainCamera;
    public float distanceBetweenSpawn = 2f;
    Vector2 screenHalfSizeWorldUnits;

    private float nextSpawnDistance;


    void Start() {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        nextSpawnDistance = distanceBetweenSpawn;
    }

    void FixedUpdate() {

        if (mainCamera.transform.position.y > nextSpawnDistance) {
            nextSpawnDistance = mainCamera.transform.position.y + distanceBetweenSpawn;
            int platformCount = Random.Range(2, 6);
            for (int i = 0; i < platformCount; i++) {
                Spawn();

            }
        }

    }

    void Spawn() {
        Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x),
                                        mainCamera.transform.position.y + 1.2f * screenHalfSizeWorldUnits.y);
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }

}
