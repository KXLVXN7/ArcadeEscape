using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Transform player; // Referensi ke pemain
    public float rocketSpeed = 5f; // Kecepatan Rocket
    public float upwardForce = 10f; // Kecepatan naik Rocket saat tombol Arrow UP ditekan
    public float downwardForce = 10f; // Kecepatan turun Rocket saat tombol Arrow DOWN ditekan
    private Rigidbody2D rb; // Rigidbody2D Rocket

    void Start()
    {
        // Mendapatkan komponen Rigidbody2D dari Rocket
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Mengecek input dari pemain untuk menggerakkan Rocket
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Menaikkan Rocket dengan gaya ke atas
            rb.velocity = new Vector2(rb.velocity.x, upwardForce);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Menurunkan Rocket dengan gaya ke bawah
            rb.velocity = new Vector2(rb.velocity.x, -downwardForce);
        }
    }

    void LateUpdate()
    {
        // Mengecek apakah Rocket dapat mengikuti pemain
        if (player != null)
        {
            // Mendapatkan arah menuju pemain
            Vector3 targetDirection = (player.position - transform.position).normalized;

            // Memastikan bahwa Rocket menghadap ke arah pemain secara horizontal
            targetDirection.y = 0f;

            // Mengatur rotasi agar Rocket menghadap ke arah pemain
            if (targetDirection != Vector3.zero)
            {
                transform.right = targetDirection;
            }

            // Menerapkan kecepatan Rocket
            transform.Translate(Vector3.right * rocketSpeed * Time.deltaTime);
        }
    }
}
