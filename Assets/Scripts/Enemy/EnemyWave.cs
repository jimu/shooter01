using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// defines a squadron of like enemies following a path.
// multiple waves form a stage

#pragma warning disable 0649
public class EnemyWave : MonoBehaviour
{
    [SerializeField] Waypoints path;
    [SerializeField] EnemyData enemy;
    [SerializeField] int numEnemy;
    [SerializeField] float interval;

    public void Start()
    {
        StartCoroutine(ReleaseEnemies());
    }

    public IEnumerator ReleaseEnemies()
    {
        while (numEnemy > 0)
        {
            yield return new WaitForSeconds(interval);
            GameObject o = PoolManager.Instance.Get(enemy.prefab, path.waypoints[0]);
            o.GetComponent<Enemy>().SetData(enemy);
            o.GetComponent<EnemyMover>().SetPath(path);
            numEnemy--;
        }

    }
}