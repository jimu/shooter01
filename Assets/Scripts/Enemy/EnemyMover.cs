using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// moves enemies along a path. path can optionally loop
public class EnemyMover : MonoBehaviour
{
    public Waypoints path;
    public float startTime;
    public Enemy enemy;
    public int currentLeg;
    public float currentLegStartDistance;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }


    public void SetPath(Waypoints path)
    {
        this.path = path;
        transform.position = path.waypoints[0];
        startTime = Time.time;
        currentLeg = 0;
        currentLegStartDistance = 0;
    }


    void Update()
    {
        float distance = (Time.time - startTime) * enemy.data.speed;

        while (distance > path.totalDistance)
        {
            if (!path.loop)
            {
                gameObject.SetActive(false);
                return;
            }
            startTime += path.totalDistance / enemy.data.speed;
            distance -= path.totalDistance;
            currentLeg = 0;
            currentLegStartDistance = 0;
        }

        float legDistance = Vector3.Distance(path.waypoints[currentLeg], path.waypoints[currentLeg + 1]);

        while (currentLegStartDistance + legDistance < distance)
        {
            currentLegStartDistance += legDistance;
            currentLeg++;
            legDistance = Vector3.Distance(path.waypoints[currentLeg], path.waypoints[currentLeg + 1]);
        }
        float fraction = (distance - currentLegStartDistance) / legDistance;

        transform.position = Vector3.Lerp(path.waypoints[currentLeg], path.waypoints[currentLeg + 1], fraction);
    }
}
