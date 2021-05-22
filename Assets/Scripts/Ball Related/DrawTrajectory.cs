using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] [Range(3, 30)] private int lineSegmentCount = 20;
    [SerializeField] Transform ballStartPosition;

    private List<Vector3> linePoints = new List<Vector3>();

    #region Singleton

    public static DrawTrajectory Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public void UpdateTrajectory(Vector3 forceVector, Rigidbody rigidbody)
    {
        Vector3 velocity = (forceVector / rigidbody.mass) * Time.fixedDeltaTime;

        float FlightDuration = (2 * velocity.y) / Physics.gravity.y;

        float stepTime = FlightDuration / lineSegmentCount;

        linePoints.Clear();

        for(int i = 0; i < lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime * i;// change in time
            Vector3 movementVector = new Vector3(
                    velocity.x * stepTimePassed,
                    velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                    velocity.z * stepTimePassed
                );
            //RaycastHit hit;

            //if (Physics.Raycast(ballStartPosition.transform.position, -movementVector, out hit, movementVector.magnitude))
            //{
            //    break;
            //}

            linePoints.Add(-movementVector + ballStartPosition.transform.position);
        }

        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPositions(linePoints.ToArray());
        
    }

    public void HideLine()
    {
        lineRenderer.positionCount = 0;
    }
}
