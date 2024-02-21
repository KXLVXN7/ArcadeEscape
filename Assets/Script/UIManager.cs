using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private GameObject gameOverUI;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
        gm.onGameOver.AddListener(ActivateGameOverUI);
    }

    public void PlayButtonHandler()
    {
        gameObject.SetActive(true);
        gm.StartGame();
        startMenuUI.SetActive(false);
    } 

    public void ActivateGameOverUI() { 
        gameOverUI.SetActive(true);
    }
    private void OnGUI()
    {
        scoreUI.text = GameManager.instance.PScore();
    }
}
