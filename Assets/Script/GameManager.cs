using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    #endregion

    public float currentScore = 0;

    public bool isPlaying = false;

    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();

    private void Update()
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime;
        }

    }

    public void StartGame()
    {
        onPlay.Invoke();
        isPlaying = true;
        Debug.Log("Start Game !");
    }
    public void GameOver()
    {
        onGameOver.Invoke();
        Debug.Log("Game Over !!");
        currentScore = 0;
        isPlaying = false;

    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitApp()
    {
        Application.Quit();
        Destroy(gameObject); // Hapus salinan ganda GameManager
    }

    public string PScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }
}
