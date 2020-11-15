using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour
{
    public WeaponMount[] weaponMounts;
    bool isAutoFiring = false;


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
#if UNITY_IOS || UNITY_ANDROID
        isAutoFiring = true;

#endif
        if (Input.GetKeyDown(KeyCode.S) || Input.GetButtonDown("Submit"))
            FireWeapon(weaponMounts[0].weapons[0], weaponMounts[0].transform);
        if (Input.GetKeyDown(KeyCode.D))
            FireWeapon(weaponMounts[1].weapons[0], weaponMounts[1].transform);
        if (Input.GetKeyDown(KeyCode.A))
            FireWeapon(weaponMounts[2].weapons[0], weaponMounts[2].transform);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ToggleAutoFire();
    }



    public void ToggleAutoFire()
    {
        isAutoFiring = !isAutoFiring;

        foreach (var weaponMount in weaponMounts)
            StartCoroutine(AutoFireWeapon(weaponMount));
    }

    public IEnumerator AutoFireWeapon(WeaponMount weaponMount)
    {
        while (isAutoFiring)
        {
            WeaponData weapon = weaponMount.weapons[0];
            FireWeapon(weapon, weaponMount.transform);
            yield return new WaitForSeconds(1 / weapon.fireRate);
        }
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
