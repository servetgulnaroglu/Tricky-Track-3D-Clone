using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassObstacle : Obstacle
{
    [SerializeField] protected GameObject[] glasses;
    public override void ChangeState(bool isRed)
    {
        if (!isRed)
        {
            for (int i = 0; i < glasses.Length; i++)
            {
                Destroy(glasses[i]);
            }
        }
    }
}
