using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public EnemyData data;
    HealthController health;

    void OnEnable()
    {
        health = GetComponent<HealthController>();
        if (data != null)
            SetData(data);
        health.SubscribeHealthChanged(CheckDeath);
    }

    private void OnDisable()
    {
        health.UnsubscribeHealthChanged(CheckDeath);
    }

    public void SetData(EnemyData data)
    {
        Debug.Log($"{name}: {data}");
        this.data = data;
        health.SetMaxHealth(data.health);

        GetComponent<EnemyRandomAttack>()?.SetData(data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckDeath(float normalizedHealth)
    {
        if (normalizedHealth <= 0f)
        {
            gameObject.SetActive(false);
            GameManager.Instance.AddScore(data.score);
        }
    }
}
