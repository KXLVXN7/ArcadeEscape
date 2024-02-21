using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.onPlay.AddListener(ActivatePlayer);
    }

    private void ActivatePlayer()
    {
        gameObject.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D others)

    {
        if (others.transform.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            // sebelumnya destroy tapi sekarang dibikin false saja active objectnya
            Debug.Log("Game Over !");
            GameManager.instance.GameOver();
        }
    }
}
