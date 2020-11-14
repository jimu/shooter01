using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stage Data", menuName = "Shooter/Stage")]
public class StageData : ScriptableObject
{
    [Tooltip("Frequency of dangerous obstacles per second")]
    public float dangerDropsPerSecond;

    [Tooltip("Danger Prefab")]
    public GameObject dangerDropPrefab;

    [Tooltip("Frequency of breakable obstacles per second")]
    public float breakableDropsPerSecond;

    [Tooltip("Breakable Prefab")]
    public GameObject breakableDropPrefab;

    [Tooltip("Frequency of Score Drops per second")]
    public float scoreDropsPerSecond;

    [Tooltip("Score Drop Prefab")]
    public GameObject scoreDropPrefab;

    [Tooltip("Frequency of Upgrade Drops per second")]
    public float upgradeDropsPerSecond;

    [Tooltip("Upgrade Drop Prefab")]
    public GameObject upgradeDropPrefab;

    [Header("Schedule waves to start for second. Leave empty for no wave at that second")]
    public EnemyWave[] waveSchedule;
}



