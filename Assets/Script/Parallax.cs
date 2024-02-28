using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material mat;
    float distance;

    [Range(0f, 0.5f)]
    public float speed = 0.2f;
    public float speedIncrement = 0.1f; // Penambahan kecepatan setiap detik

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }


    void Update()
    {
        distance += (speed + speedIncrement * Time.deltaTime) * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
}
