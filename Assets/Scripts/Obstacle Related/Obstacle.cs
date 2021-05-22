using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Super class of obstacles
 */
public class Obstacle : MonoBehaviour
{
    //called when target get shot
    public virtual void ChangeState(bool isRed)
    {
    }
}
