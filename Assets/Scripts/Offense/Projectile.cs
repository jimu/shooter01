using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Shooter/Projectile")]
public class Projectile : ScriptableObject
{
    [Tooltip("Projectile description")]
    new public string descripton;

    [Tooltip("Pool used to instantiate this weapon")]
    public Pool pool;

    [Tooltip("Damage")]
    public float damage;

    [Tooltip("Projectile Speed")]
    public float speed;

    [Tooltip("Particle Effect when hit target")]
    public ParticleSystem impactVFX;
}
