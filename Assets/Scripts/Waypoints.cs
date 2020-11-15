using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Constructs a path from it's children
// enemy waves follow this path
public class Waypoints : MonoBehaviour
{
    public List<Vector3> waypoints;
    public float totalDistance;
    public bool loop;

    // Start is called before the first frame update
    void Awake()
    {
        ConstructWaypoints();
    }

    public void ConstructWaypoints()
    {
        waypoints = new List<Vector3>();
        totalDistance = 0;
        Vector3 lastPos = default;

        for (int i = 0; i < transform.childCount; ++i)
        {
            Vector3 pos = transform.GetChild(i).position;
            waypoints.Add(pos);
            totalDistance += i == 0 ? 0 : Vector3.Distance(lastPos, pos);
            lastPos = pos;
        }

        if (loop)
        {
            waypoints.Add(waypoints[0]);
            totalDistance += Vector3.Distance(lastPos, waypoints[0]);
        }
    }
}
