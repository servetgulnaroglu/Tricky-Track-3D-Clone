using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected ObstacleSystem obstacleSystem;

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("EnemyBall")) {
            obstacleSystem.ChangeState();
        }
    }

    public ObstacleSystem GetObstacleSystem()
    {
        return this.obstacleSystem;
    }

      
}
