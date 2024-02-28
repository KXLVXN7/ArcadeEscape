using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private Transform obstacleParent;

    public float obstacleSpawnTime = 2f;

    public float obstacleSpeed = 3f;
    private float timeUntilObstacleSpawn;

    private float elapsedTime; // Waktu yang telah berlalu sejak penambahan terakhir
    private int speedIncreaseCount; // Jumlah penambahan kecepatan

    private void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            SpawnLoop();
            IncreaseSpeed();
        }
    }

    private void Start()
    {
        GameManager.instance.onGameOver.AddListener(ClearObstacle);
        elapsedTime = 0f;
        speedIncreaseCount = 0;
    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstacleSpawnTime)
        {
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }

    private void ClearObstacle()
    {
        foreach (Transform child in obstacleParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void Spawn()
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        spawnedObstacle.transform.parent = obstacleParent;

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
        Debug.Log("Spawn Obstacle Spike");
    }

    private void IncreaseSpeed()
    {
        // Update waktu yang telah berlalu
        elapsedTime += Time.deltaTime;

        // Jika sudah 10 detik dan belum mencapai maksimal penambahan speed, tambahkan speed
        if (elapsedTime >= 10f && speedIncreaseCount < 10)
        {
            obstacleSpeed += 1f;
            elapsedTime = 0f; // Reset waktu yang telah berlalu
            speedIncreaseCount++; // Tambah jumlah penambahan speed
        }
    }
}
