using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Implements a scrolling background
// Usage: attach this script to a repeating image.
// Attach a second copy of the image as a child GameObject to provide seamless repeating texture

#pragma warning disable 0649

[RequireComponent(typeof(BoxCollider))]
public class DropMover : MonoBehaviour
{
    [Tooltip("Units/second image moves down")]
    [SerializeField] float verticalSpeed;
    float minY;

    private void Awake()
    {
        minY = GameManager.Instance.minY - GetComponent<BoxCollider>().size.y;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= verticalSpeed * Time.deltaTime;
        if (pos.y < minY)
            gameObject.SetActive(false);
        transform.position = pos;
    }
}
