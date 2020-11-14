using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour
{
    public WeaponMount[] weaponMounts;
    
    public Weapon weaponAlternate1;

    void Start()
    {
        foreach(WeaponMount mount in weaponMounts)
            SetWeapon(mount);
    }

    void SetWeapon(WeaponMount mount, GameObject prefab = null)
    {
        for (int i = 0; i < mount.transform.childCount; ++i)
            Destroy(mount.transform.GetChild(0).gameObject);
        Instantiate(prefab == null ? mount.weapons[0].prefab : prefab, mount.transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            SetWeapon(weaponMounts[0], weaponAlternate1.prefab);
        if (Input.GetKeyDown(KeyCode.F))
            ProjectileLauncher.Launch(weaponMounts[0].weapons[0].projectile, weaponMounts[0].transform);
        if (Input.GetKeyDown(KeyCode.G))
            ProjectileLauncher.Launch(weaponMounts[1].weapons[0].projectile, weaponMounts[1].transform);
        if (Input.GetKeyDown(KeyCode.H))
            ProjectileLauncher.Launch(weaponMounts[2].weapons[0].projectile, weaponMounts[2].transform);
    }
}
