using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Used in hill obstacle
 */
public class Smasher : MonoBehaviour
{
    [SerializeField] Transform posOfAfterSmash;

    public Transform GetPosOfAfterSmash()
    {
        return this.posOfAfterSmash;
    }
}
