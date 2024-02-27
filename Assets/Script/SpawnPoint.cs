using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private Transform obstacleParent;

    public float obstacleSpawnTime = 2f;

    public float obstacleSpeed = 3f;
    private float timeUntilObstacleSpawn;

    private void Update()
    {   
        if (GameManager.instance.isPlaying)
        {
            SpawnLoop();
        }

    }

    private void Start()
    {
        GameManager.instance.onGameOver.AddListener(ClearObstacle);
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
        foreach(Transform child in obstacleParent)
        {
            Destroy(child.gameObject);
        }
    }
    private void Spawn()
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        transform.rotation = Quaternion.identity;
        spawnedObstacle.transform.parent = obstacleParent;

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
    }
}
