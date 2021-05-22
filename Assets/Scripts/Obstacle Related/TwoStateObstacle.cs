using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoStateObstacle : Obstacle
{
    [SerializeField] private Animator animator;

    public override void ChangeState(bool isRed)
    {
        animator.SetBool("isRed", isRed);
    }

}
