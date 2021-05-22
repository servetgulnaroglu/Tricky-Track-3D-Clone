using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class to implement red or green obstacles
 */
public class TwoStateObstacle : Obstacle
{
    [SerializeField] private Animator animator;

    public override void ChangeState(bool isRed)
    {
        animator.SetBool("isRed", isRed);
    }

}
