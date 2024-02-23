using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Transform player; // Referensi ke pemain
    public float rocketSpeed = 5f; // Kecepatan Rocket
    public float upwardForce = 10f; // Kecepatan naik Rocket saat tombol Arrow UP ditekan
    public float downwardForce = 10f; // Kecepatan turun Rocket saat tombol Arrow DOWN ditekan
    public float maxHoldTime = 2f; // Waktu maksimum menahan Rocket setelah tombol ditekan
    private bool canFollowPlayer = true; // Apakah Rocket dapat mengikuti pemain
    private float holdTime = 0f; // Waktu menahan Rocket setelah tombol ditekan

    void LateUpdate()
    {
        // Mengecek apakah Rocket dapat mengikuti pemain
        if (canFollowPlayer && player != null)
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

            // Menahan Rocket setelah tombol ditekan
            if (holdTime > 0f)
            {
                holdTime -= Time.deltaTime;
                if (holdTime <= 0f)
                {
                    canFollowPlayer = true;
                }
            }

            // Jika Rocket sudah mencapai pemain, maka berhenti mengikuti dan tetap bergerak ke kiri
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer < 0.1f) // Ubah nilai jarak yang sesuai dengan kebutuhan Anda
            {
                canFollowPlayer = false;
            }
        }
    }

    // Method untuk menghentikan Rocket mengikuti pemain
    public void StopFollowingPlayer()
    {
        canFollowPlayer = false;
    }

    // Method untuk menaikkan Rocket saat tombol Arrow UP ditekan
    public void MoveUp()
    {
        if (canFollowPlayer)
        {
            transform.Translate(Vector3.up * upwardForce * Time.deltaTime);
            holdTime = maxHoldTime;
            canFollowPlayer = false;
        }
    }

    // Method untuk menurunkan Rocket saat tombol Arrow DOWN ditekan
    public void MoveDown()
    {
        if (canFollowPlayer)
        {
            transform.Translate(Vector3.down * downwardForce * Time.deltaTime);
            holdTime = maxHoldTime;
            canFollowPlayer = false;
        }
    }
}
