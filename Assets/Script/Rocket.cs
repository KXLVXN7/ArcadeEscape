using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    public Transform player; // Referensi ke pemain
    public float rocketSpeed = 5f; // Kecepatan Rocket
    public float upwardForce = 1f; // Kecepatan naik Rocket saat tombol Arrow UP ditekan
    public float downwardForce = 1f; // Kecepatan turun Rocket saat tombol Arrow DOWN ditekan
    private Rigidbody2D rb; // Rigidbody2D Rocket
    private bool isUpwardPressed = false; // Apakah tombol Arrow UP sedang ditekan
    private bool isDownwardPressed = false; // Apakah tombol Arrow DOWN sedang ditekan

    void Start()
    {
        // Mendapatkan komponen Rigidbody2D dari Rocket
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Mengecek input dari pemain untuk menggerakkan Rocket
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Menaikkan Rocket dengan gaya ke atas
            isUpwardPressed = true;
            StartCoroutine(StopUpward());
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Menurunkan Rocket dengan gaya ke bawah
            isDownwardPressed = true;
            StartCoroutine(StopDownward());
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

    // Coroutine untuk menghentikan gaya naik setelah 2 detik
    IEnumerator StopUpward()
    {
        yield return new WaitForSeconds(1f);
        isUpwardPressed = false;
    }

    // Coroutine untuk menghentikan gaya turun setelah 2 detik
    IEnumerator StopDownward()
    {
        yield return new WaitForSeconds(1f);
        isDownwardPressed = false;
    }

    void FixedUpdate()
    {
        // Menggerakkan Rocket sesuai input pemain
        if (isUpwardPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, upwardForce);
        }
        else if (isDownwardPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, -downwardForce);
        }
    }
}
