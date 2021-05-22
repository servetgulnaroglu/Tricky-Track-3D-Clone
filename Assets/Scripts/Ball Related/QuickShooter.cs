using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickShooter : DragAndShoot
{
    // Update is called once per frame

    //private bool isStarted = false;

    //void Update()
    //{
    //    if (isStarted)
    //    {
    //        UpdateTrajectoryAndForceVector();
    //    }
    //}

    //public void StartQuickShots()
    //{
    //    isStarted = true;
    //    StartCoroutine(QuickShotCoroutine());
    //}

    //IEnumerator QuickShotCoroutine()
    //{
    //    StartShootProcessWithVisibleLine();
    //    yield return new WaitForSeconds(0.5f);
    //    StartCoroutine(QuickShotCoroutine());
    //}

    //protected override void CalculateThrowVector()
    //{
    //    Vector3 vector = -mousePressDownPos + mouseReleasePos;
    //    Vector3 rotatedVector = vector;
    //    if (rotatedVector.y > 0)
    //    {
    //        throwVector = new Vector3(rotatedVector.x, rotatedVector.y / 2, rotatedVector.y * 3) * ballForce;
    //    }
    //}

    //protected override void UpdateTrajectoryAndForceVector()
    //{
    //    mouseReleasePos = Input.mousePosition;
    //    CalculateThrowVector();
    //    DrawTrajectory.Instance.UpdateTrajectory(throwVector, ballRigidbody);
    //}

    //protected override void StartShootProcess()
    //{
    //    DrawTrajectory.Instance.HideLine();
    //    mouseReleasePos = Input.mousePosition;
    //    CalculateThrowVector();
    //    player.ThrowBall(throwVector, false);
    //}

    //protected override void StartShootProcessWithVisibleLine()
    //{
    //    mouseReleasePos = Input.mousePosition;
    //    CalculateThrowVector();
    //    player.ThrowBall(throwVector, false);
    //}
}
