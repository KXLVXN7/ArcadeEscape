using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D others)
    {
        if (others.transform.tag == "Obstacle")
        {
            Destroy(gameObject);
            // Destroy
            Debug.Log("Game Over !");
            GameManager.instance.GameOver();
        }
    }
}
