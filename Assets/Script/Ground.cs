using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject groundPrefab; // Prefab objek tanah
    public GameObject spawnPoint; // Titik spawn untuk Ground 2
    public float groundSpeed = 5f; // Kecepatan pergerakan tanah ke kiri
    public float spawnInterval = 5f; // Interval waktu antara setiap spawn
    public float destroyOffset = 20f; // Jarak dari layar kamera di mana tanah akan dihancurkan

    private float screenRight;
    private float spawnTimer;

    void Start()
    {
        screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)).x;
        spawnTimer = 0f;
    }

    void Update()
    {
        // Menggerakkan Ground 1 ke kiri dengan kecepatan tertentu setiap frame
        transform.Translate(Vector3.left * groundSpeed * Time.deltaTime);

        // Jika Ground 1 berada di luar layar kamera, hancurkan objek
        if (transform.position.x < -screenRight - destroyOffset)
        {
            Destroy(gameObject);
        }

        // Menambah timer
        spawnTimer += Time.deltaTime;

        // Jika waktu spawn telah mencapai interval, lakukan spawn Ground 2
        if (spawnTimer >= spawnInterval)
        {
            SpawnGround2();
            spawnTimer = 0f; // Reset timer
        }
    }

    void SpawnGround2()
    {
        // Membuat instance objek Ground 2 baru dari prefab di titik spawn
        GameObject newGround2 = Instantiate(groundPrefab, spawnPoint.transform.position, Quaternion.identity);

        // Atur parent Ground 2 agar menjadi objek Ground saat ini
        newGround2.transform.parent = transform.parent;
    }
}
