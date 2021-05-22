using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAI : MonoBehaviour
{
    [SerializeField] private bool isLeftSide;
    [SerializeField] private Player player;
    [SerializeField] private Transform ballStarPos;
    private Target tempTarget;

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Target"))
    //    {
    //        tempTarget = other.gameObject.GetComponent<Target>();
    //        if (isLeftSide && tempTarget.GetObstacleSystem().GetIsCurrentlyRed())
    //        {
    //            ProcessShoot(other.gameObject.transform.position);
    //        } else if (!isLeftSide && !tempTarget.GetObstacleSystem().GetIsCurrentlyRed())
    //        {
    //            ProcessShoot(other.gameObject.transform.position);
    //        }
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            tempTarget = other.gameObject.GetComponent<Target>();
            if (isLeftSide && tempTarget.GetObstacleSystem().GetIsCurrentlyRed())
            {
                ProcessShoot(tempTarget.transform.position);
            }
            else if (!isLeftSide && !tempTarget.GetObstacleSystem().GetIsCurrentlyRed())
            {
                ProcessShoot(tempTarget.transform.position);
            }
        }
    }

    private void ProcessShoot(Vector3 targetPos)
    {
        Vector3 differenceVector = targetPos - ballStarPos.gameObject.transform.position;
        float time = 1.2f;
        Vector3 forceVector = new Vector3(((2 * differenceVector.x) / (time*time)),
            ((2  * differenceVector.y) / (time*time) - Physics.gravity.y/3), (2 * differenceVector.z) / (time*time ));
        player.ThrowBall(forceVector, true);
    }
}
