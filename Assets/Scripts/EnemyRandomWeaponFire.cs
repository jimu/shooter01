using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomWeaponFire : MonoBehaviour
{
    EnemyData data;
    float cooldownExpires = 0f;

    private void OnEnable()
    {
        cooldownExpires = Time.time + 0.5f;    
    }

    public void SetData(EnemyData data)
    {
        this.data = data;
    }

    private void Update()
    {
        if (Time.time > cooldownExpires && Random.value < data.fireChance * Time.deltaTime)
        {
            GameObject projectile = ProjectileLauncher.Launch(data.projectile, transform);
            projectile.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}
