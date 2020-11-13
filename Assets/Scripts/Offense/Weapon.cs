using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Pool { ShellProjectile, LaserProjectile, MissileProjectile, Enemy, EnemyProjectile }

[CreateAssetMenu(fileName = "New Weapon", menuName = "Shooter/Weapon")]
public class Weapon : ScriptableObject
{
    [Tooltip("Weapon name")]
    new public string name;

    [Tooltip("Pool used to instantiate this weapon")]
    public Pool pool;

    [Tooltip("Projectile this weapon fires")]
    public Projectile projectile;

    [Tooltip("Rounds per second")]
    public float fireRate;

    [Tooltip("Particle Effect when fired")]
    public ParticleSystem dischargeVFX;

    [Tooltip("Upgrades to this weapon")]
    public Weapon upgrade;

    [Tooltip("Cost to upgrade this weapon")]
    public int upgradeCost;
}



