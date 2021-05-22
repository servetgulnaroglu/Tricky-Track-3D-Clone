using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject restartButton;

    private void Start()
    {
        startButton.SetActive(true);
        restartButton.SetActive(false);
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        restartButton.SetActive(false);
        FindObjectOfType<LevelManager>().StartGame();
    }

    public void RestartGame()
    {
        FindObjectOfType<LevelManager>().ResetGame();
    }

    public void ShowRestartButton()
    {
        startButton.SetActive(false);
        restartButton.SetActive(true);
    }
}
