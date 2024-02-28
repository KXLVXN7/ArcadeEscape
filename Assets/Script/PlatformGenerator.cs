using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab; // Prefab platform yang akan di-generate
    public float distanceBetweenPlatforms; // Jarak antara setiap platform yang digenerate
    public float spawnDelay; // Delay antara generasi platform

    private float lastSpawnX; // Posisi X dari platform terakhir yang di-generate

    void Start()
    {
        // Mulai dengan meng-generate platform pertama
        GeneratePlatform();
    }

    void Update()
    {
        // Cek jika posisi pemain lebih besar dari posisi X dari platform terakhir yang di-generate
        if (transform.position.x > lastSpawnX - distanceBetweenPlatforms)
        {
            // Jika iya, generate platform baru setelah jeda tertentu
            Invoke("GeneratePlatform", spawnDelay);
        }
    }

    void GeneratePlatform()
    {
        // Hitung posisi generasi platform baru
        Vector3 spawnPosition = new Vector3(lastSpawnX + distanceBetweenPlatforms, transform.position.y, transform.position.z);

        // Instantiate platform prefab pada posisi yang telah dihitung
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

        // Update posisi X dari platform terakhir yang di-generate
        lastSpawnX = spawnPosition.x;
    }
}
