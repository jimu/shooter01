
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementController : MonoBehaviour
{
    [Tooltip("Speed of player ship")]
    public float speed = 30f;

    bool movingEnabled = true;
    private float minX, maxX, minY, maxY;



    public void Awake()
    {
        SetMargins();
    }

    private void SetMargins()
    {
        if (Camera.main.orthographic)
            SetMarginsOrthographicCamera();
        else
            SetMarginsPerspectiveCamera();
    }

    private void SetMarginsPerspectiveCamera()
    {
        Vector3 margin = GetComponentInChildren<BoxCollider>().bounds.extents;
        RaycastHit hitData;

        if (Physics.Raycast(Camera.main.ViewportPointToRay(Vector3.zero), out hitData, 1000))
        {
            Vector3 worldPosition = hitData.point;
            minX = worldPosition.x + margin.x * 1.5f;
            minY = worldPosition.y + margin.y * 1.5f;
        }
        if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(1, 1, 0)), out hitData, 1000))
        {
            Vector3 worldPosition = hitData.point;
            maxX = worldPosition.x - margin.x * 1.5f;
            maxY = worldPosition.y - margin.y * 1.5f;
        }
    }

    private void SetMarginsOrthographicCamera()
    {
        Vector3 margin = GetComponentInChildren<BoxCollider>().bounds.extents;
        minX = Camera.main.ViewportToWorldPoint(Vector2.zero).x + margin.x;
        minY = Camera.main.ViewportToWorldPoint(Vector2.zero).y + margin.y;
        maxX = Camera.main.ViewportToWorldPoint(Vector2.right).x - margin.x;
        maxY = Camera.main.ViewportToWorldPoint(Vector2.up).y - margin.y;
    }

    public void TogglePerspective()
    {
        Camera.main.orthographic = !Camera.main.orthographic;
        SetMargins();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), 0);
    }


    private void MoveTowards(Vector3 pos)
    {
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
    }

    private void MoveTowardsScreenPoint(Vector3 pos)
    {
        if (Camera.main.orthographic)
        {
            MoveTowards(Camera.main.ScreenToWorldPoint(pos));
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData, 1000))
            {
                MoveTowards(hitData.point);
            }
        }
    }

    private void Update()
    {
        if (movingEnabled)
        {
#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_WEBGL
            if (Input.GetMouseButton(0)) //if mouse button was pressed       
                MoveTowardsScreenPoint(Input.mousePosition);
#endif
#if UNITY_IOS || UNITY_ANDROID
            if (Input.touchCount == 1)
                MoveTowardsScreenPoint(Input.touches[0].position);
#endif
        }
    }
}
