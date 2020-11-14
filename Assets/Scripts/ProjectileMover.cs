using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Moves projectiles and removes them when they exceed their range
 */
public class ProjectileMover : MonoBehaviour
{
    /*[HideInInspector] */public ProjectileData projectile;

    float expireTime;

    public void SetProjectile(ProjectileData projectile)
    {
        this.projectile = projectile;
        expireTime = Time.time + projectile.range / projectile.speed;
    }

    void Update()
    {
        if (Time.time > expireTime)
            gameObject.SetActive(false);
        else
            transform.Translate(Vector3.up * projectile.speed * Time.deltaTime);
    }
}
