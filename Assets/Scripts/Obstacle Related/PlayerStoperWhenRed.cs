using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * When an obstacle is red, it kicks the player to a certain position. So that player can hit the target 
 */
public class PlayerStoperWhenRed : MonoBehaviour
{
    [SerializeField] private ObstacleSystem obstacleSystem;
    private Player currentChar;
    Vector3 posOfFirstHit;
    void Start()
    {
        currentChar = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (obstacleSystem.GetIsCurrentlyRed())
        {
            posOfFirstHit = other.gameObject.transform.position;
            if (other.gameObject.CompareTag("Player"))
            {
                currentChar = FindObjectOfType<LevelManager>().GetPlayer();
                currentChar.SetCurrentObstacleSystemAndZPos(this.obstacleSystem, posOfFirstHit.z);
            }
            else if (other.gameObject.CompareTag("Enemy"))
            {
                currentChar = FindObjectOfType<LevelManager>().GetEnemy();
                currentChar.SetCurrentObstacleSystemAndZPos(this.obstacleSystem, posOfFirstHit.z); ;
            }
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (obstacleSystem.GetIsCurrentlyRed())
        {
            if (other.gameObject.CompareTag("Player"))
            {
                currentChar = FindObjectOfType<LevelManager>().GetPlayer();
                currentChar.SetCurrentObstacleSystemAndZPos(this.obstacleSystem, posOfFirstHit.z);
            }
            else if (other.gameObject.CompareTag("Enemy"))
            {
                currentChar = FindObjectOfType<LevelManager>().GetEnemy();
                currentChar.SetCurrentObstacleSystemAndZPos(this.obstacleSystem, posOfFirstHit.z); ;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))  && currentChar != null)
        {
            currentChar.SetCurrentObstacleSystemAndZPos(null, 0f);
            currentChar = null;
        }
    }
}
