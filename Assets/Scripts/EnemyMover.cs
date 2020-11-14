using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public Waypoints path;
    public float lastFraction;
    public float startTime;
    public Enemy enemy;
    public int currentLeg;
    public float currentLegStartDistance;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = path.waypoints[0];
        lastFraction = 0f;
        startTime = Time.time;
        currentLeg = 0;
        currentLegStartDistance = 0;
    }


    void Update()
    {
        float distance = ((Time.time - startTime) * enemy.data.speed) % path.totalDistance;

        if (distance < currentLegStartDistance )
        {
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
