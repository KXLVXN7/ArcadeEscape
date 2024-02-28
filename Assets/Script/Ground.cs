using UnityEngine;

public class Ground : MonoBehaviour
{
    public float groundSpeed = 5f; // Kecepatan pergerakan tanah ke kiri
    public float speedIncrement = 1f; // Penambahan kecepatan setiap 10 detik
    public float maxSpeedIncrement = 10f; // Jumlah maksimal penambahan kecepatan

    private float elapsedTime; // Waktu yang telah berlalu sejak penambahan terakhir
    private int speedIncreaseCount; // Jumlah penambahan kecepatan

    void Start()
    {
        elapsedTime = 0f;
        speedIncreaseCount = 0;
    }

    void Update()
    {
        // Menggerakkan Ground ke kiri dengan kecepatan tertentu setiap frame
        transform.Translate(Vector3.left * groundSpeed * Time.deltaTime);

        // Update waktu yang telah berlalu
        elapsedTime += Time.deltaTime;

        // Jika sudah 10 detik dan belum mencapai maksimal penambahan speed, tambahkan speed
        if (elapsedTime >= 10f && speedIncreaseCount < maxSpeedIncrement)
        {
            groundSpeed += speedIncrement;
            elapsedTime = 0f; // Reset waktu yang telah berlalu
            speedIncreaseCount++; // Tambah jumlah penambahan speed
        }
    }
}
