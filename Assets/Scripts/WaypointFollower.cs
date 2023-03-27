using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed, timeToMove;
    [SerializeField] private bool xAxis = true, yAxis = true;
    private Vector2 position, currentDestination = Vector2.zero;
    private int currentWaypoint;

    void Update()
    {
        position = transform.position;
        currentDestination.x = xAxis ? waypoints[currentWaypoint].position.x : position.x;
        currentDestination.y = yAxis ? waypoints[currentWaypoint].position.y : position.y;

        if (Vector2.Distance(position, currentDestination) < 0.1f)
        {
            currentWaypoint++;

            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
        else
        {
            position = Vector2.MoveTowards(transform.position, currentDestination, speed * Time.deltaTime);        }

        transform.position = position;
    }
}
