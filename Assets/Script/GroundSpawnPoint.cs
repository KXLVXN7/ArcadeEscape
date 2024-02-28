using UnityEngine;

public class GroundSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] groundPrefabs;
    [SerializeField] private Transform groundParent;

    public float groundSpawnTime = 2f;
    public float groundSpeed = 3f;
    public float destroyTime = 10f; // Waktu sebelum klon dihancurkan
    public float spawnTimeIncrement = 0.1f; // Penambahan waktu spawn setiap 10 detik
    public float maxSpawnTimeIncrement = 2f; // Penambahan waktu spawn maksimal
    public float minGroundSpawnTime = 0.5f; // Waktu spawn minimum
    public int maxSpeedIncreaseCount = 10; // Jumlah maksimal penambahan kecepatan

    private float timeUntilGroundSpawn;
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
        GameManager.instance.onGameOver.AddListener(ClearGround);
        elapsedTime = 0f;
        speedIncreaseCount = 0;
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

        // Hancurkan klon setelah waktu destroy yang ditentukan
        Destroy(spawnedGround, destroyTime);
        Debug.Log("Destroy Spawned Ground");

        Debug.Log("Spawn Ground");
    }

    private void IncreaseSpeed()
    {
        // Update waktu yang telah berlalu
        elapsedTime += Time.deltaTime;

        // Jika sudah 10 detik dan belum mencapai maksimal penambahan speed, tambahkan speed
        if (elapsedTime >= 10f && speedIncreaseCount < maxSpeedIncreaseCount)
        {
            groundSpawnTime = Mathf.Max(minGroundSpawnTime, groundSpawnTime - spawnTimeIncrement);
            elapsedTime = 0f; // Reset waktu yang telah berlalu
            speedIncreaseCount++; // Tambah jumlah penambahan speed
        }
    }
}
