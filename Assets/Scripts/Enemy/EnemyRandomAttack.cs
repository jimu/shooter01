using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// implmenets enemy's who fire at a random rate/chance
public class EnemyRandomAttack : MonoBehaviour
{
    EnemyData data;
    float cooldownExpires = 0f;

    private void OnEnable()
    {
        ResetCooldown();
    }

    public void SetData(EnemyData data)
    {
        this.data = data;
        ResetCooldown();
    }

    void ResetCooldown()
    {
        cooldownExpires = Time.time + 0.5f;
    }


    private void Update()
    {
        if (Time.time > cooldownExpires && Random.value < data.fireChance * Time.deltaTime)
        {
            GameObject projectile = ProjectileLauncher.Launch(data.projectile, data.fireSFX, transform);
            projectile.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}
