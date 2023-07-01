using System.Collections;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public Transform[] wayPoints;
    public Transform[] controlPoints;
    private Vector3 startPoint, endPoint;
    [SerializeField] private float cameraSpeed = 0.5f;
    private int next = 1;


    private void OnDrawGizmos()
    {
        int sigmentsNumber = 20;
        Vector3 preveousePoint = wayPoints[0].position;
        int controlPointsCount = 1;

        for (int i = 1; i < wayPoints.Length; i++)
        {
            
            for (int j = 0; j < sigmentsNumber + 1; j++)
            {
                float paremeter = (float)j / sigmentsNumber;
                Vector3 point = GetPoint(wayPoints[i-1].position, controlPoints[controlPointsCount-1].position, controlPoints[controlPointsCount].position, wayPoints[i].position, paremeter);
                Gizmos.DrawLine(preveousePoint, point);
                preveousePoint = point;
            }
            controlPointsCount += 2;
        }
    }

    public  Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            oneMinusT * oneMinusT * oneMinusT * p0 +
            3f * oneMinusT * oneMinusT * t * p1 +
            3f * oneMinusT * t * t * p2 +
            t * t * t * p3;
    }

    public Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            3f * oneMinusT * oneMinusT * (p1 - p0) +
            6f * oneMinusT * t * (p2 - p1) +
            3f * t * t * (p3 - p2);
    }

    void Start()
    {
        startPoint = wayPoints[next - 1].position;
        endPoint = wayPoints[next].position;
    }

    void Update()
    {
        StartCoroutine(MoveCamera());
    }

    private IEnumerator MoveCamera()
    {
        Vector3 preveousePoint = wayPoints[0].position;
        int controlPointsCount = 0;
        int wayPointsCount = 1;
        float duration = 1f;
        float paremeter = 0f;

        while (true)
        {
            while(paremeter < duration)
            {
                if (wayPointsCount != wayPoints.Length || controlPointsCount != controlPoints.Length)
                {
                    paremeter += cameraSpeed * Time.deltaTime;
                    transform.position = GetPoint(wayPoints[wayPointsCount - 1].position, controlPoints[controlPointsCount].position,
                                                  controlPoints[controlPointsCount + 1].position, wayPoints[wayPointsCount].position, paremeter);
                    transform.rotation = Quaternion.LookRotation(GetFirstDerivative(wayPoints[wayPointsCount - 1].position, controlPoints[controlPointsCount].position,
                                                  controlPoints[controlPointsCount + 1].position, wayPoints[wayPointsCount].position, paremeter));
                    yield return null;
                }
                else
                {
                    controlPointsCount = 0;
                    wayPointsCount = 1;
                    paremeter += cameraSpeed * Time.deltaTime;
                    transform.position = GetPoint(wayPoints[wayPointsCount - 1].position, controlPoints[controlPointsCount].position,
                                                  controlPoints[controlPointsCount + 1].position, wayPoints[wayPointsCount].position, paremeter);
                    transform.rotation = Quaternion.LookRotation(GetFirstDerivative(wayPoints[wayPointsCount - 1].position, controlPoints[controlPointsCount].position,
                                                  controlPoints[controlPointsCount + 1].position, wayPoints[wayPointsCount].position, paremeter));
                    yield return null;
                }

            }
            wayPointsCount++;
            controlPointsCount += 2;
            paremeter = 0f;
        }
    }
}
