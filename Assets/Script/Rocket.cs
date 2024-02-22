using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Transform player; // Referensi ke pemain
    public float rocketSpeed = 5f; // Kecepatan Rocket
    private bool canFollowPlayer = true; // Apakah Rocket dapat mengikuti pemain

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
        }
    }

    // Method untuk menghentikan Rocket mengikuti pemain
    public void StopFollowingPlayer()
    {
        canFollowPlayer = false;
    }
}
