using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// moves drop objects down the screen

#pragma warning disable 0649

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
