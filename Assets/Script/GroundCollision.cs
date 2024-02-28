using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GroundDestroyer"))
        {
            if (!gameObject.CompareTag("Player"))
            { // Pastikan objek yang bertabrakan bukan objek asli
                Destroy(gameObject); // Menghancurkan klon (clone)
            }
        }
    }
}
