using UnityEngine;

public class GroundSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] groundPrefabs;
    [SerializeField] private Transform groundParent;

    public float groundSpawnTime = 2f;
    public float groundSpeed = 3f;
    public float speedIncrement = 0.1f; // Penambahan kecepatan setiap detik
    public float destroyTime = 10f; // Waktu sebelum klon dihancurkan

    private float timeUntilGroundSpawn;

    private void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            SpawnLoop();

            // Tambahkan speed increment setiap detik
            groundSpeed += speedIncrement * Time.deltaTime;
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

        // Hancurkan klon setelah waktu destroy yang ditentukan
        Destroy(spawnedGround, destroyTime);
        Debug.Log("Destroy Spawned Ground");

        Debug.Log("Spawn Ground");
    }
}
