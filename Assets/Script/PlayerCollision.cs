using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Vector3 initialPosition; // Menyimpan posisi awal objek player
    private Rigidbody2D rb; // Rigidbody player
    private Transform Stickman_Idle; // Transform dari playerGFX

    private void Start()
    {
        // Mengambil komponen Rigidbody2D dari parent (objek player)
        rb = GetComponentInParent<Rigidbody2D>();

        // Mengambil transform dari playerGFX (anak pertama objek player)
        Stickman_Idle = transform.parent.Find("Stickman_Idle");

        // Simpan posisi awal objek player
        initialPosition = transform.parent.position;

        // Daftarkan fungsi ActivatePlayer() sebagai listener untuk event onPlay
        GameManager.instance.onPlay.AddListener(ActivatePlayer);
    }

    private void ActivatePlayer()
    {
        // Aktifkan kembali objek player dan kembalikan ke posisi awal
        transform.parent.gameObject.SetActive(true);
        transform.parent.position = initialPosition;
        // Reset kecepatan player
        rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Obstacle"))
        {
            // Panggil fungsi GameOver() pada GameManager
            GameManager.instance.GameOver();

            // Nonaktifkan objek player
            transform.parent.gameObject.SetActive(false);
        }
    }
}
