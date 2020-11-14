using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour
{
    public WeaponMount[] weaponMounts;
    public Weapon weapon1;

    public Weapon weapon2;

    public Weapon weapon3;

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
        {
            GameObject o = PoolManager2.Instance.Get(weaponMounts[0].weapons[0].projectile.prefab, weaponMounts[0].transform);
            o.GetComponent<ProjectileMover>().SetProjectile(weaponMounts[0].weapons[0].projectile);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject o = PoolManager2.Instance.Get(weaponMounts[1].weapons[0].projectile.prefab, weaponMounts[1].transform);
            o.GetComponent<ProjectileMover>().SetProjectile(weaponMounts[1].weapons[0].projectile);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            GameObject o = PoolManager2.Instance.Get(weaponMounts[2].weapons[0].projectile.prefab, weaponMounts[2].transform);
            o.GetComponent<ProjectileMover>().SetProjectile(weaponMounts[2].weapons[0].projectile);
        }

    }
}
