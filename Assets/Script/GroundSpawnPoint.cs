using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] groundPrefabs;
    [SerializeField] private Transform groundParent;

    public float groundSpawnTime = 2f;
    public float groundSpeed = 3f;

    private float timeUntilGroundSpawn;

    private void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            SpawnLoop();
        }
    }

    private void Start()
    {
        GameManager.instance.onGameOver.AddListener(ClearGround);
    }

    private void SpawnLoop()
    {
        timeUntilGroundSpawn += Time.deltaTime;

        if (timeUntilGroundSpawn >= groundSpawnTime)
        {
            Spawn();
            timeUntilGroundSpawn = 0f;
        }
    }

    private void ClearGround()
    {
        foreach (Transform child in groundParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void Spawn()
    {
        GameObject groundToSpawn = groundPrefabs[Random.Range(0, groundPrefabs.Length)];

        GameObject spawnedGround = Instantiate(groundToSpawn, transform.position, Quaternion.identity);
        spawnedGround.transform.parent = groundParent;

        // Pindahkan ground yang di-spawn ke kiri berdasarkan kecepatan tanah yang ditentukan
        spawnedGround.transform.Translate(Vector3.left * groundSpeed * Time.deltaTime);
        Debug.Log("Spawn Ground");
    }
}
