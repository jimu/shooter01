using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class RepeatingBackground : MonoBehaviour
{
    [SerializeField] float verticalSpeed;

    public Vector3 translation;
    float offsetY;
    float offsetLimitY;

    void Awake()
    {
        Vector3 pos = transform.position;
        offsetY = GetComponent<MeshCollider>().bounds.size.y;
        offsetLimitY = pos.y - offsetY;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= verticalSpeed * Time.deltaTime;
        if (pos.y < offsetLimitY)
            pos.y += offsetY;
        transform.position = pos;
    }
}
