using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public float turnSpeed = 10f;
    
    private int waypointIndex = 1;

    void Start()
    {
    }

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        if (waypointIndex >= waypoints.Length)
        {
            Destroy(gameObject);
            return;
        }

        Transform targetWaypoint = waypoints[waypointIndex];

        Vector3 direction = targetWaypoint.position - transform.position;

        if (direction != Vector3.zero) 
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.4f)
        {
            waypointIndex++;
        }
    }
}