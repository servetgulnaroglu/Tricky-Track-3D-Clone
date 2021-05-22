using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * 
 * Level informations is collected in LevelManager
 * 
 */
public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Player enemy;
    [SerializeField] private UIManager uiManager;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public Player GetPlayer()
    {
        return this.player;
    }


    public Player GetEnemy()
    {
        return this.enemy;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
    }

    public void ResetGame() {
        SceneManager.LoadScene(0);
    }

    public void OnLose()
    {
        uiManager.ShowRestartButton();
    }

    public void OnWin()
    {
        uiManager.ShowRestartButton();
    }
}
