using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 5f;  // How often enemies spawn
    private float spawnTimer;
    public float spawnIncreaseRate = 0.1f;  // Increase frequency over time

    void Update()
    {
        spawnTimer += Time.deltaTime;

        // Check if it’s time to spawn a new enemy
        if (spawnTimer >= spawnRate)
        {
            Instantiate(enemyPrefab, transform.position+new Vector3(0,2f,-1f), Quaternion.identity);
            spawnTimer = 0;
            // Decrease spawnRate to spawn enemies faster over time
            spawnRate = Mathf.Max(1f, spawnRate - spawnIncreaseRate); // Avoid going below 1 second
        }
    }
}
