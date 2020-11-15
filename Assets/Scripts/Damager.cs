using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// hurts MonoDamagable objecs
public class Damager : MonoBehaviour
{

    [HideInInspector] public ProjectileData projectile;
    int remainingTargets;


    public void SetProjectile(ProjectileData projectile)
    {
        this.projectile = projectile;
        remainingTargets = projectile.maxTargetsHit;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(projectile.damagesTag))
        {
            other.GetComponent<MonoDamagable>().Damage(projectile.damage);

            if (--remainingTargets <= 0)
                gameObject.SetActive(false);

        }
    }

}
