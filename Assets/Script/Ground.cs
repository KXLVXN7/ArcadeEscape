using UnityEngine;

public class Ground : MonoBehaviour
{
    public float groundSpeed = 5f; // Kecepatan pergerakan tanah ke kiri

    void Update()
    {
        // Menggerakkan Ground ke kiri dengan kecepatan tertentu setiap frame
        transform.Translate(Vector3.left * groundSpeed * Time.deltaTime);
    }
}
