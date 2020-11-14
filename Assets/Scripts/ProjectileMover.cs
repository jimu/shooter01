using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    //[SerializeField] float speed;
    [HideInInspector] public Projectile projectile;

    float expireTime;

    // Start is called before the first frame update
    public void SetProjectile(Projectile projectile)
    {
        this.projectile = projectile;
        expireTime = Time.time + projectile.range / projectile.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > expireTime)
            gameObject.SetActive(false);
        else
            transform.Translate(Vector3.up * projectile.speed * Time.deltaTime);
    }
}
