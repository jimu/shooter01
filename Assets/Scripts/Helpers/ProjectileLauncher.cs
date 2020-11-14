using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher
{
    static public GameObject Launch(Projectile projectile, Transform transform)
    {
        GameObject o = PoolManager.Instance.Get(projectile.prefab, transform);
        o.GetComponent<ProjectileMover>().SetProjectile(projectile);
        o.GetComponent<Damager>().SetProjectile(projectile);
        return o;
    }
}
