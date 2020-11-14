using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Shooter/Projectile")]
public class Projectile : ScriptableObject
{
    [Tooltip("Projectile description")]
    public string descripton;

    [Tooltip("Pool used to instantiate projectiles")]
    public GameObject prefab;

    [Tooltip("Damage")]
    public float damage;

    [Tooltip("Projectile Speed")]
    public float speed;

    [Tooltip("Projectile Range")]
    public float range;

    [Tooltip("Particle Effect when hit target")]
    public ParticleSystem impactVFX;
}
