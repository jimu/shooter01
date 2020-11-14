using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour
{
    public WeaponMount[] weaponMounts;


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
        if (Input.GetKeyDown(KeyCode.G))
            FireWeapon(weaponMounts[0].weapons[0], weaponMounts[0].transform);
        if (Input.GetKeyDown(KeyCode.H))
            FireWeapon(weaponMounts[1].weapons[0], weaponMounts[1].transform);
        if (Input.GetKeyDown(KeyCode.F))
            FireWeapon(weaponMounts[2].weapons[0], weaponMounts[2].transform);
    }

    void FireWeapon(WeaponData weapon, Transform transform)
    {
        ProjectileLauncher.Launch(weapon.projectile, weapon.fireSFX, transform);
    }

    public void UpgradeWeapon(int index)
    {
        if (weaponMounts[index].weapons[0].upgrade != null)
            weaponMounts[index].weapons[0] = weaponMounts[index].weapons[0].upgrade;
    }
}
