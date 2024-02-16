using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Walls"))
        {
            if (!gameObject.CompareTag("Player"))
            { // Pastikan objek yang bertabrakan bukan objek asli
                Destroy(gameObject); // Menghancurkan klon (clone)
            }
        }
    }
}
