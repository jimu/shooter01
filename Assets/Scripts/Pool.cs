using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#pragma warning disable 0649

public class Pool
{
    GameObject prefab;
    Transform parent;

    public Pool(GameObject prefab, Transform parent)
    {
        this.prefab = prefab;
        this.parent = parent;
    }

    // Note: msdn documentation claims Lists use an array internally and should perform just as fast
    List<GameObject> pool = new List<GameObject>();
    int lastIndex = -1;

    /*
    public GameObject Get()
    {
        for (int count = pool.Count; count-- > 0;)
        {
            lastIndex = (lastIndex + 1) % pool.Count;
            if (pool[lastIndex] == null)
                return pool[lastIndex] = GameObject.Instantiate(prefab);
            if (!pool[lastIndex].activeSelf)
            {
                GameObject o = pool[lastIndex];
                o.SetActive(true);
                return o;
            }
        }
        return null;
    }
    */
    public GameObject Get(Vector3 position)
    {
        GameObject o;
        //Debug.Log($"pool: {pool}");
        for (int count = pool.Count; count-- > 0;)
        {
            lastIndex = (lastIndex + 1) % pool.Count;
            if (pool[lastIndex] == null)
                return pool[lastIndex] = GameObject.Instantiate(prefab, position, Quaternion.identity, parent);
            if (!pool[lastIndex].activeSelf)
            {
                o = pool[lastIndex];
                o.transform.position = position;
                o.SetActive(true);
                return o;
            }
        }
        o = GameObject.Instantiate(prefab, position, Quaternion.identity, parent);
        pool.Add(o);
        return o;
    }

    public GameObject Get(Transform parent)
    {
        GameObject o;
        //Debug.Log($"pool: {pool}");
        for (int count = pool.Count; count-- > 0;)
        {
            lastIndex = (lastIndex + 1) % pool.Count;
            if (!pool[lastIndex].activeSelf)
            {
                o = pool[lastIndex];
                o.transform.position = parent.position;
                o.transform.rotation = parent.rotation;
                o.SetActive(true);
                return o;
            }
        }
        o = GameObject.Instantiate(prefab, parent.position, parent.rotation, parent);
        pool.Add(o);
        return o;
    }

    /*
    public void Release(GameObject o)
    {
        o.SetActive(false);
    }
    */
}
