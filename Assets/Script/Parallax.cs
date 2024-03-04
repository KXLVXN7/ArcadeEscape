using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material mat;
    float distance;
    float currentSpeed; // Kecepatan aktual
    float elapsedTime; // Waktu yang telah berlalu sejak penambahan terakhir

    [Range(0f, 0.5f)]
    public float speed = 0.2f;
    public float speedIncrement = 0.1f; // Penambahan kecepatan setiap 10 detik
    public float maxSpeedIncrement = 100f; // Maksimal penambahan kecepatan

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        currentSpeed = speed; // Inisialisasi kecepatan aktual
        elapsedTime = 0f; // Inisialisasi waktu yang telah berlalu
    }

    void Update()
    {
        // Update waktu yang telah berlalu
        elapsedTime += Time.deltaTime;

        // Jika sudah 10 detik dan speed belum mencapai maksimal, tambahkan speed
        if (elapsedTime >= 10f && currentSpeed < maxSpeedIncrement)
        {
            currentSpeed += speedIncrement;
            elapsedTime = 0f; // Reset waktu yang telah berlalu
        }

        // Hitung pergeseran jarak berdasarkan kecepatan aktual
        distance += currentSpeed * Time.deltaTime;

        // Atur pergeseran tekstur
        mat.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
}
