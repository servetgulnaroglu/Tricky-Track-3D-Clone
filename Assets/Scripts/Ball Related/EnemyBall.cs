using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : Ball
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            gotHitByEnemyBall = true;
            UnfreezePosition();
        }
    }
}
