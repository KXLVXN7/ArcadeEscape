using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Transform player; // Referensi ke pemain
    public float acceleration = 1f; // Percepatan arah Rocket
    public float maxSpeed = 10f; // Kecepatan maksimal Rocket
    public float speedIncrement = 1f; // Penambahan kecepatan setiap detik
    public float maxSpeedIncrement = 50f; // Maksimal penambahan kecepatan setelah 50 detik
    private float elapsedTime; // Waktu yang telah berlalu sejak penambahan terakhir

    private Rigidbody2D rb; // Rigidbody2D Rocket
    private bool isUpwardPressed = false; // Apakah tombol Arrow UP sedang ditekan
    private bool isDownwardPressed = false; // Apakah tombol Arrow DOWN sedang ditekan
    public float upwardForce = 1f; // Kecepatan naik Rocket saat tombol Arrow UP ditekan
    public float downwardForce = 1f; // Kecepatan turun Rocket saat tombol Arrow DOWN ditekan

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        elapsedTime = 0f; // Inisialisasi waktu yang telah berlalu
    }

    void Update()
    {
        // Mengambil input tombol Arrow Up dan Arrow Down
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isDownwardPressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isUpwardPressed = true;
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            // Mendapatkan arah menuju pemain
            Vector2 directionToPlayer = (player.position - transform.position).normalized;

            // Menghitung percepatan arah
            Vector2 accelerationVector = directionToPlayer * acceleration * Time.deltaTime;

            // Mengatur kecepatan Rocket dengan percepatan arah
            Vector2 currentVelocity = rb.velocity;
            currentVelocity.x = -maxSpeed; // Terbang ke kiri
            currentVelocity += accelerationVector;

            // Memastikan kecepatan Rocket tidak melebihi kecepatan maksimal
            currentVelocity = Vector2.ClampMagnitude(currentVelocity, maxSpeed);

            // Atur kecepatan Rocket
            rb.velocity = currentVelocity;
        }
        else
        {
            // Jika tidak ada pemain, biarkan rocket terbang ke kiri dengan kecepatan maksimal
            rb.velocity = new Vector2(-maxSpeed, 0f);
        }

        // Menggerakkan Rocket sesuai input pemain
        if (isUpwardPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, upwardForce);
            isUpwardPressed = false;
        }
        else if (isDownwardPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, -downwardForce);
            isDownwardPressed = false;
        }

        // Update waktu yang telah berlalu
        elapsedTime += Time.deltaTime;

        // Jika sudah 10 detik dan speed belum mencapai maksimal, tambahkan speed
        if (elapsedTime >= 10f && maxSpeed < maxSpeedIncrement)
        {
            maxSpeed += speedIncrement;
            elapsedTime = 0f; // Reset waktu yang telah berlalu
        }
    }
}
