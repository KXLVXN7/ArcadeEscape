using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject rocketPrefab; // Prefab Rocket yang akan di-spawn
    public Transform spawnPoint; // Titik spawn untuk Rocket

    public float spawnInterval = 2f; // Interval waktu antara setiap spawn
    private float spawnTimer; // Waktu yang telah berlalu sejak spawn terakhir

    void Start()
    {
        spawnTimer = 0f;
    }

    void Update()
    {
        // Menghitung waktu sejak spawn terakhir
        spawnTimer += Time.deltaTime;

        // Jika sudah mencapai interval waktu spawn, lakukan spawn
        if (spawnTimer >= spawnInterval)
        {
            SpawnRocket();
            spawnTimer = 0f; // Reset timer
        }
    }

    void SpawnRocket()
    {
        // Membuat instance Rocket dari prefab di titik spawn
        GameObject rocketInstance = Instantiate(rocketPrefab, spawnPoint.position, Quaternion.identity);

        // Catatan: Rocket tidak akan memiliki kecepatan awal karena kita tidak memberikan kecepatan saat spawn
    }
}
