using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{

    [HideInInspector] public Projectile projectile;


    public void SetProjectile(Projectile projectile)
    {
        this.projectile = projectile;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(projectile.damagesTag))
        {
            Debug.Log($"I damaged {other.name} doing {projectile.damage}");
            other.GetComponent<MonoDamagable>().Damage(projectile.damage);
        }
    }

}
