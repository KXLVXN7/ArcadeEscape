using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Transform player; // Referensi ke pemain
    public float acceleration = 1f; // Percepatan arah Rocket
    public float maxSpeed = 10f; // Kecepatan maksimal Rocket
    public float speedIncrement = 1f; // Penambahan kecepatan setiap detik

    private Rigidbody2D rb; // Rigidbody2D Rocket
    private bool isUpwardPressed = false; // Apakah tombol Arrow UP sedang ditekan
    private bool isDownwardPressed = false; // Apakah tombol Arrow DOWN sedang ditekan
    public float upwardForce = 1f; // Kecepatan naik Rocket saat tombol Arrow UP ditekan
    public float downwardForce = 1f; // Kecepatan turun Rocket saat tombol Arrow DOWN ditekan

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        // Menambahkan peningkatan kecepatan setiap detik
        maxSpeed += speedIncrement * Time.deltaTime;
    }
}
