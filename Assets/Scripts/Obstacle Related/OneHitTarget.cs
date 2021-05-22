using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Used at the end of level as one hit target
 * Target is destroyed when it gets a shot
 */
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
