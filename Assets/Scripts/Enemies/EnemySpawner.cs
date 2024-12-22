using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject meleeEnemyPrefab;
    public GameObject rangedEnemyPrefab;
    public float spawnInterval = 3f;
    private float spawnCooldown;

    public Transform spawnPoint; // Set this in the Inspector to define where enemies should spawn

    private void Start()
    {
        spawnCooldown = spawnInterval; // Initialize spawn cooldown
    }

    private void Update()
    {
        spawnCooldown -= Time.deltaTime;

        if (spawnCooldown <= 0)
        {
            SpawnEnemy();
            spawnCooldown = spawnInterval; // Reset cooldown
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = null;

        // Randomly choose between melee and ranged enemies
        if (Random.Range(0, 2) == 0)
        {
            enemy = Instantiate(meleeEnemyPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            enemy = Instantiate(rangedEnemyPrefab, spawnPoint.position, Quaternion.identity);
        }

    }
}
