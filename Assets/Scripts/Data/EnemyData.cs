using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Shooter/Enemy")]
public class EnemyData : ScriptableObject
{
    [Tooltip("Enemy name")]
    new public string name;

    [Tooltip("Prefab used to instantiate this enemy")]
    public GameObject prefab;

    [Tooltip("Projectile this enemy fires")]
    public Projectile projectile;

    [Tooltip("Chance to fire per second")]
    public float fireChance;

    [Tooltip("Particle Effect when firing")]
    public ParticleSystem dischargeVFX;

    [Tooltip("Health of this enemy")]
    public int health;

    [Tooltip("Speed of this enemy")]
    public int speed;
}



