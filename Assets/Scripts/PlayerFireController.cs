using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour
{
    public WeaponMount[] weaponMounts;
    
    public Weapon weaponAlternate1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PlayerFireController.Start");
        foreach(WeaponMount mount in weaponMounts)
        {
            Debug.Log($" * {mount} weapon {mount.weapons[0]} pos {mount.transform.position}");
            //Instantiate(mount.weapons[0u].prefab, mount.transform);
            SetWeapon(mount);
        }
    }

    void SetWeapon(WeaponMount mount, GameObject prefab = null)
    {
        for (int i = 0; i < mount.transform.childCount; ++i)
            Destroy(mount.transform.GetChild(0).gameObject);
        Instantiate(prefab == null ? mount.weapons[0].prefab : prefab, mount.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            SetWeapon(weaponMounts[0], weaponAlternate1.prefab);
        if (Input.GetKeyDown(KeyCode.F))
            LaunchProjectile(weaponMounts[0].weapons[0].projectile, weaponMounts[0].transform);
        if (Input.GetKeyDown(KeyCode.G))
            LaunchProjectile(weaponMounts[1].weapons[0].projectile, weaponMounts[1].transform);
        if (Input.GetKeyDown(KeyCode.H))
            LaunchProjectile(weaponMounts[2].weapons[0].projectile, weaponMounts[2].transform);

    }

    void LaunchProjectile(Projectile projectile, Transform source)
    {
        GameObject o = PoolManager2.Instance.Get(projectile.prefab, source);
        o.GetComponent<ProjectileMover>().SetProjectile(projectile);
        o.GetComponent<Damager>().SetProjectile(projectile);
    }
}
