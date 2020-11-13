using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Implements a scrolling background
// Usage: attach this script to a repeating image.
// Attach a second copy of the image as a child GameObject to provide seamless repeating texture

#pragma warning disable 0649

[RequireComponent(typeof(MeshCollider))]
public class RepeatingBackground : MonoBehaviour
{
    [Tooltip("Units/second image moves down")]
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
