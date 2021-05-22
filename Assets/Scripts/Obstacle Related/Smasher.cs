using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smasher : MonoBehaviour
{
    [SerializeField] Transform posOfAfterSmash;

    public Transform GetPosOfAfterSmash()
    {
        return this.posOfAfterSmash;
    }
}
