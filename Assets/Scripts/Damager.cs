using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{

    [HideInInspector] public Projectile projectile;
    int remainingTargets;


    public void SetProjectile(Projectile projectile)
    {
        this.projectile = projectile;
        remainingTargets = projectile.maxTargetsHit;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(projectile.damagesTag))
        {
            Debug.Log($"I damaged {other.name} doing {projectile.damage}");
            other.GetComponent<MonoDamagable>().Damage(projectile.damage);

            if (--remainingTargets <= 0)
                gameObject.SetActive(false);

        }
    }

}
