using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Shooter/Weapon")]
public class Weapon : ScriptableObject
{
    [Tooltip("Weapon name")]
    new public string name;

    [Tooltip("Prefab used to instantiate this weapon")]
    public GameObject prefab;

    [Tooltip("Projectile that this weapon fires")]
    public Projectile projectile;

    [Tooltip("Rounds per second")]
    public float fireRate;

    [Tooltip("Particle Effect when fired")]
    public ParticleSystem fireVFX;

    [Tooltip("Sound Effect when fired")]
    public AudioClip fireSFX;

    [Tooltip("Upgrades to this weapon")]
    public Weapon upgrade;

    [Tooltip("Cost to upgrade this weapon")]
    public int upgradeCost;
}



