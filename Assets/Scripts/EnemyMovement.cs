using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float speed;
 
    private Transform[] movePoints;
    private Vector3[] pointsPosition;
    private float minDistance = 0.1f;
    private int pointIndex = 0;

    private void Awake()
    {
        movePoints = WaypointsSystem.instance.GetWaypoints();
        pointsPosition = new Vector3[movePoints.Length];

        for (int i = 0; i < movePoints.Length; i++)
        {
            pointsPosition[i] = movePoints[i].position;
        }
    }

    private void Update()
    {
        MoveToThePoint();
    }

    private void MoveToThePoint()
    {
        var distance = Vector3.Distance(pointsPosition[pointIndex], transform.position);

        transform.LookAt(pointsPosition[pointIndex]);

        if (distance < minDistance)
            pointIndex++;

        else
            transform.position = Vector3.MoveTowards(transform.position, pointsPosition[pointIndex], speed * Time.deltaTime);
    }
}
