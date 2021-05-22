using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Player enemy;
    [SerializeField] private float distancePlayerShouldStopWhenRedTarget = 3f;
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

    public float GetDistancePlayerShouldStopWhenRedTarget()
    {
        return this.distancePlayerShouldStopWhenRedTarget;
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
