using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher
{
    static public GameObject Launch(Projectile projectile, Transform source)
    {
        GameObject o = PoolManager2.Instance.Get(projectile.prefab, source);
        o.GetComponent<ProjectileMover>().SetProjectile(projectile);
        o.GetComponent<Damager>().SetProjectile(projectile);
        return o;
    }
}
