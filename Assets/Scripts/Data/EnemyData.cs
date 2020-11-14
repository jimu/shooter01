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

    [Tooltip("Weapon cooldown time in seconds")]
    public float cooldown;

    [Tooltip("Sound effect when firing")]
    public AudioClip fireSFX;

    [Tooltip("Particle effect when firing")]
    public ParticleSystem fireVFX;

    [Tooltip("Health of this enemy")]
    public int health;

    [Tooltip("Speed of this enemy")]
    public int speed;

    [Tooltip("Score value of this enemy")]
    public int score;

    [Tooltip("Sound effect when hurt")]
    public AudioClip hurtSFX;

    [Tooltip("Particle effect when hurt")]
    public ParticleSystem hurtVFX;

    [Tooltip("Sound effect when killed")]
    public AudioClip destroyedSFX;

    [Tooltip("Particle effect when killed")]
    public ParticleSystem destroyedVFX;
}



