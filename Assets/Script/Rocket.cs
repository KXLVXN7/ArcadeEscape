using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Transform player; // Referensi ke pemain
    public float rocketSpeed = 5f; // Kecepatan Rocket
    public float liftForce = 10f; // Kekuatan naik untuk mencegah jatuhnya Rocket
    private bool canControl = true; // Apakah Rocket bisa dikendalikan
    private float controlTime = 2f; // Durasi waktu kontrol setelah pemain menekan tombol
    private float currentControlTime = 0f; // Waktu kontrol saat ini

    void Update()
    {
        // Jika Rocket bisa dikendalikan dan waktu kontrol belum habis
        if (canControl && currentControlTime <= 0f)
        {
            // Mengecek input pemain untuk mengubah arah Rocket
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Jika tombol Arrow Up ditekan, Rocket naik
                transform.Translate(Vector3.up * rocketSpeed * Time.deltaTime);
                currentControlTime = controlTime; // Mulai waktu kontrol
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Jika tombol Arrow Down ditekan, Rocket turun
                transform.Translate(Vector3.down * rocketSpeed * Time.deltaTime);
                currentControlTime = controlTime; // Mulai waktu kontrol
            }
        }

        // Mengurangi waktu kontrol jika masih ada waktu tersisa
        if (currentControlTime > 0f)
        {
            currentControlTime -= Time.deltaTime;
        }
    }

    void LateUpdate()
    {
        // Jika Rocket bisa dikendalikan dan waktu kontrol habis
        if (canControl && currentControlTime <= 0f)
        {
            // Rocket akan terus mengejar pemain
            Vector3 targetDirection = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            transform.Translate(Vector3.right * rocketSpeed * Time.deltaTime); // Menggunakan right agar Rocket selalu menghadap ke arah pemain
            ApplyLiftForce(); // Menerapkan kekuatan naik untuk mencegah jatuh
        }
    }

    // Method untuk menerapkan kekuatan naik untuk mencegah jatuhnya Rocket
    void ApplyLiftForce()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, liftForce);
    }

    // Method untuk menghentikan kendali Rocket
    public void StopControl()
    {
        canControl = false;
    }

    // Method untuk mengaktifkan kembali kendali Rocket
    public void StartControl()
    {
        canControl = true;
    }
}
