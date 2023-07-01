using UnityEngine;

[ExecuteInEditMode]
public class Points : MonoBehaviour
{
    public Transform point1; // Первая точка
    public Transform point2; // Вторая точка
    public Transform point3; // Третья точка

    private Vector3 offSet;

    private void Update()
    {
        if (Application.isPlaying == false)
        {
            if (point1.hasChanged)
            {
                offSet = point1.position - point2.position;
                point3.position = point2.position - offSet;
                point1.hasChanged = false;
            }
            if (point3.hasChanged)
            {
                offSet = point2.position - point3.position;
                point1.position = point2.position + offSet;
                point3.hasChanged = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(point1.position, point2.position);
        Gizmos.DrawLine(point2.position, point3.position);
    }
}
