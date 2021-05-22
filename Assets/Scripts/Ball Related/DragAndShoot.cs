using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragAndShoot : MonoBehaviour
{

    protected Vector3 mousePressDownPos;
    protected Vector3 mouseReleasePos;
    [SerializeField] protected Transform cameraTransform;
    [SerializeField] protected float ballForce;
    [SerializeField] protected Rigidbody ballRigidbody;
    protected Vector3 throwVector;
    [SerializeField] protected Player player;
    private bool areQuickShotsStarted = false;
    [SerializeField] 


    private void Update()
    {
        if (areQuickShotsStarted)
            UpdateTrajectoryAndForceVector();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        StartShootProcess();
    }

    private void OnMouseDrag()
    {
        UpdateTrajectoryAndForceVector();
    }

    //calculates the force should be applied to the ball
    protected virtual void CalculateThrowVector()
    {
        Vector3 vector = -mousePressDownPos + mouseReleasePos;
        Vector3 rotatedVector = vector;
        //rotatedVector = Quaternion.AngleAxis(cameraTransform.eulerAngles.x, Vector3.left) * vector;
        //rotatedVector = Quaternion.AngleAxis(cameraTransform.eulerAngles.y, Vector3.down) * rotatedVector;
        //rotatedVector = Quaternion.AngleAxis(cameraTransform.eulerAngles.z, Vector3.back) * rotatedVector;
        //throwVector = new Vector3(rotatedVector.x / 3, rotatedVector.y / 2, rotatedVector.y) * ballForce;
        if (rotatedVector.y > 0)
        {
            throwVector = new Vector3(rotatedVector.x, rotatedVector.y / 2, rotatedVector.y * 3) * ballForce;
        }
    }

    protected virtual void UpdateTrajectoryAndForceVector()
    {
        mouseReleasePos = Input.mousePosition;
        CalculateThrowVector();
        DrawTrajectory.Instance.UpdateTrajectory(throwVector, ballRigidbody);
    }

    protected virtual void StartShootProcess()
    {
        if (!areQuickShotsStarted)
        {
            DrawTrajectory.Instance.HideLine();
        }
        mouseReleasePos = Input.mousePosition;
        CalculateThrowVector();
        player.ThrowBall(throwVector, false);
    }

    //called when end of the level comes
    public void StartQuickShots()
    {
        areQuickShotsStarted = true;
        StartCoroutine(QuickShotCoroutine());
    }

    //in the end of the level, it is recursively called to throw balls constantly
    IEnumerator QuickShotCoroutine()
    {
        StartShootProcess();
        yield return new WaitForSeconds(player.GetBallReadyDelay());
        StartCoroutine(QuickShotCoroutine());
    }

}
