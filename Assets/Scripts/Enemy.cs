﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages enemy data and initializes other enemy components
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
        //Debug.Log($"{name}: {data}");
        this.data = data;
        health.Init(data.health, data.hurtSFX, data.hurtVFX, data.destroyedSFX, data.destroyedVFX);

        GetComponent<EnemyRandomAttack>()?.SetData(data);
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
