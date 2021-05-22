using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHitTarget : Target
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("EnemyBall"))
        {
            obstacleSystem.ChangeState();
            Destroy(this.gameObject);
        }
    }
}
