using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls enemy waves and random drops
public class StageManager : MonoBehaviour
{
    public StageData data;
    public int nextWave = 0;

    public void Update()
    {   if (Time.timeScale > 0)
        {
            if (Random.value / Time.deltaTime < data.scoreDropsPerSecond)
                Drop(data.scoreDropPrefab);
            if (Random.value / Time.deltaTime < data.dangerDropsPerSecond)
                Drop(data.dangerDropPrefab);
            if (Random.value / Time.deltaTime < data.upgradeDropsPerSecond)
                Drop(data.upgradeDropPrefab);
            if (Random.value / Time.deltaTime < data.breakableDropsPerSecond)
                Drop(data.breakableDropPrefab);
        }

        while (Time.time > nextWave && nextWave < data.waveSchedule.Length)
        {   if (data.waveSchedule[nextWave] != null)
                Instantiate(data.waveSchedule[nextWave]);
            nextWave++;
        }
    }

    void Drop(GameObject prefab)
    {
        float x = Random.Range(GameManager.Instance.minX, GameManager.Instance.maxX);
        float y = GameManager.Instance.maxY + 3;
        float height = prefab.GetComponent<BoxCollider>().size.y;
        PoolManager.Instance.Get(prefab, new Vector3(x, y + height, 0));
    }
}
