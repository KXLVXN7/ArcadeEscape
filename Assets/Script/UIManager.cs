using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }
    private void OnGUI()
    {
        scoreUI.text = GameManager.instance.PScore();
    }
}
