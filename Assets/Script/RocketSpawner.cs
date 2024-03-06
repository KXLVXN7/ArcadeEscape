using UnityEngine;
using UnityEngine.UI;
public class RocketSpawner : MonoBehaviour
{
    [SerializeField] Rocket rocket;
    [SerializeField] Button _upButton;
    [SerializeField] Button _downButton;

    public GameObject rocketPrefab; // Prefab Rocket yang akan di-spawn
    public Transform spawnPoint; // Titik spawn untuk Rocket


    public float spawnInterval1 = 2f; // Interval waktu antara setiap spawn untuk interval 1
    public float spawnInterval2 = 5f; // Interval waktu antara setiap spawn untuk interval 2
    private float spawnTimer; // Waktu yang telah berlalu sejak spawn terakhir

    void Start()
    {
        spawnTimer = 0f;
    }

    void Update()
    {
        // Menghitung waktu sejak spawn terakhir
        spawnTimer += Time.deltaTime;

        // Cek apakah sudah mencapai interval 1 atau interval 2
        if (spawnTimer >= spawnInterval1)
        {
            SpawnRocket();
            spawnTimer = 0f; // Reset timer
        }
        else if (spawnTimer >= spawnInterval2)
        {
            SpawnRocket();
            spawnTimer = spawnInterval1; // Mulai kembali dari interval 1 setelah mencapai interval 2
        }
    }

    void SpawnRocket()
    {
        // Membuat instance Rocket dari prefab di titik spawn
        Rocket rocketInstance = Instantiate(rocket, spawnPoint.position, Quaternion.identity);
        Debug.Log("Spawn Rocket !");

        rocketInstance.Setup(_upButton, _downButton);

        // Catatan: Rocket tidak akan memiliki kecepatan awal karena kita tidak memberikan kecepatan saat spawn
    }
}