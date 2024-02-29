using UnityEngine;

public class Ground : MonoBehaviour
{
    public static float elapsedTime; // Waktu yang telah berlalu sejak penambahan terakhir
    public static int speedIncreaseCount; // Jumlah penambahan kecepatan

    public float groundSpeed = 5f; // Kecepatan pergerakan tanah ke kiri
    public float speedIncrement = 3f; // Penambahan kecepatan setiap 10 detik
    public float timeToWait = 10f; // Waktu yang harus ditunggu sebelum penambahan pertama
    private bool speedIncreased = false; // Menandakan apakah kecepatan sudah ditambahkan

    void Start()
    {
        ResetSpeedIncrease();
    }

    void Update()
    {
        // Menggerakkan Ground ke kiri dengan kecepatan tertentu setiap frame
        transform.Translate(Vector3.left * groundSpeed * Time.deltaTime);

        // Update waktu yang telah berlalu
        elapsedTime += Time.deltaTime;

        // Jika belum ada peningkatan kecepatan dan sudah melewati waktu yang ditunggu untuk penambahan pertama
        if (!speedIncreased && elapsedTime >= timeToWait)
        {
            groundSpeed += speedIncrement; // Tambah kecepatan
            speedIncreased = true; // Tandai bahwa kecepatan telah ditambahkan
        }
    }

    // Method untuk mereset waktu yang telah berlalu dan status peningkatan kecepatan
    private void ResetSpeedIncrease()
    {
        elapsedTime = 0f;
        speedIncreased = false;
    }
}
