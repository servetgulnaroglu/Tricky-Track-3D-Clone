using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelarator : TwoStateObstacle
{
    [SerializeField] ObstacleSystem obstacleSystem;
    [SerializeField] private float initialYScale = 600f;
    [SerializeField] private float accelaratorPercentage = 30f;

    void Start()
    {
        initialYScale = transform.localScale.y;
    }

    public override void ChangeState(bool isRed)
    {
        Vector3 scale = transform.localScale;
        if (isRed)
            scale.y = initialYScale;
        else
            scale.y = -initialYScale;
        transform.localScale = scale;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ProcessIncrement(obstacleSystem.GetIsCurrentlyRed() ? -accelaratorPercentage : accelaratorPercentage, FindObjectOfType<LevelManager>().GetPlayer());
        } else if (other.gameObject.CompareTag("Enemy"))
        {
            ProcessIncrement(obstacleSystem.GetIsCurrentlyRed() ? -accelaratorPercentage : accelaratorPercentage, FindObjectOfType<LevelManager>().GetEnemy());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ProcessIncrement(obstacleSystem.GetIsCurrentlyRed() ? -accelaratorPercentage : accelaratorPercentage, FindObjectOfType<LevelManager>().GetPlayer());
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            ProcessIncrement(obstacleSystem.GetIsCurrentlyRed() ? -accelaratorPercentage : accelaratorPercentage, FindObjectOfType<LevelManager>().GetEnemy());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ProcessIncrement(0, FindObjectOfType<LevelManager>().GetPlayer());
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            ProcessIncrement(0, FindObjectOfType<LevelManager>().GetEnemy());
        }
    }

    private void ProcessIncrement(float increment, Player player)
    {
        player.SetIncrementOfSpeedAsPercentage(increment);
    }
}
