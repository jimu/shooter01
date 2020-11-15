using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// one lousy helper function used by player and enemy alike
public class ProjectileLauncher
{
    static public GameObject Launch(ProjectileData projectile, AudioClip sfx, Transform transform)
    {
        AudioManager.Instance.PlayOneShot(sfx);
        GameObject o = PoolManager.Instance.Get(projectile.prefab, transform);
        o.GetComponent<ProjectileMover>().SetProjectile(projectile);
        o.GetComponent<Damager>().SetProjectile(projectile);
        return o;
    }
}
