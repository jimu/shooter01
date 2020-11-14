using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Implements a Pool of objects
 * 
 * Example usage:
 * 
 */
#pragma warning disable 0649
public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] GameObject prefab;
    [SerializeField] int maxSize;
    GameObject[] pool;
    int lastIndex = -1;


    protected override void Init()
    {
        //Debug.Log("PoolManager.Init()");
        pool = new GameObject[maxSize];
        //Debug.Log($"  pool: {pool}");
    }

    public GameObject Get()
    {
        //Debug.Log($"pool: {pool}");
        for (int count = pool.Length; count-- > 0;)
        {
            lastIndex = (lastIndex + 1) % pool.Length;
            if (pool[lastIndex] == null)
                return pool[lastIndex] = Instantiate(prefab);
            if (!pool[lastIndex].activeSelf)
            {
                GameObject o = pool[lastIndex];
                o.SetActive(true);
                return o;
            }
        }
        return null;
    }
    public GameObject Get(Vector3 position)
    {
        //Debug.Log($"pool: {pool}");
        for (int count = pool.Length; count-- > 0;)
        {
            lastIndex = (lastIndex + 1) % pool.Length;
            if (pool[lastIndex] == null)
                return pool[lastIndex] = Instantiate(prefab, position, Quaternion.identity, transform);
            if (!pool[lastIndex].activeSelf)
            {
                GameObject o = pool[lastIndex];
                o.transform.position = position;
                o.SetActive(true);
                return o;
            }
        }
        return null;
    }


    public Dictionary<GameObject, Pool> Pools;
    public Pool GetPool(GameObject prefab)
    {
        if (Pools.ContainsKey(prefab))
        {
            return Pools[prefab];
        }
        return Pools[prefab] = new Pool(prefab, transform);
    }

    public void Release(GameObject o)
    {
        o.SetActive(false);
    }
}
