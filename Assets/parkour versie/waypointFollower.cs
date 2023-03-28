using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints; // Array van waypoints
    int currentWaypointIndex = 0; // Index van het huidige waypoint

    [SerializeField] float speed = 1f; // Snelheid waarmee het object beweegt tussen waypoints

    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 0.1f)
        {
            // Als het object dichtbij genoeg bij het huidige waypoint is, ga naar het volgende waypoint
            currentWaypointIndex++;


            // Als we alle waypoints hebben bereikt, begin opnieuw
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
            // Draai het object 180 graden
            transform.Rotate(0f, 180f, 0f);
        }

        // Beweeg het object naar het volgende waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
