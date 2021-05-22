using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class to control who wins.
 */
public class FinishLine : MonoBehaviour
{

    private bool gameFinished;
    private bool isPlayerWinner;
    void Start()
    {
        gameFinished = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameFinished)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isPlayerWinner = true;
                gameFinished = true;
            } else if (other.gameObject.CompareTag("Enemy")){
                isPlayerWinner = false;
                gameFinished = true;
            }
        }
        if (gameFinished)
        {
            if (isPlayerWinner)
            {
                FindObjectOfType<LevelManager>().GetPlayer().StartWinCondition();
                FindObjectOfType<LevelManager>().GetEnemy().StopAndFailDance();
            }
            else {
                FindObjectOfType<LevelManager>().GetPlayer().StopAndFailDance();
                FindObjectOfType<LevelManager>().GetEnemy().StopAndWinDance();
                FindObjectOfType<LevelManager>().OnLose();
            }  
        }
    }


}
