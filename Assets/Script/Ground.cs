using UnityEngine;

public class Ground : MonoBehaviour
{
    public float groundSpeed = 5f; // Kecepatan pergerakan tanah ke kiri
    public float destroyOffset = 20f; // Jarak dari layar kamera di mana tanah akan dihancurkan

    private float screenRight;
    private bool isClone = false;

    void Start()
    {
        screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)).x;
        if (transform.parent != null)
        {
            isClone = true;
        }
    }

    void Update()
    {
        // Menggerakkan Ground ke kiri dengan kecepatan tertentu setiap frame
        transform.Translate(Vector3.left * groundSpeed * Time.deltaTime);

        // Jika Ground berada di luar layar kamera, hancurkan klon
        if (isClone && transform.position.x < -screenRight)
        {
        /*    Destroy(gameObject);
            Debug.Log("Destroy Ground Clone");*/
        }
    }
}
