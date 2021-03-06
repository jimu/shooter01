﻿using System;
using UnityEngine;

// Sets objects health, accepts damage, notifies subscribers of health change

public class HealthController : MonoDamagable
{
    static readonly int MAX_HEALTH_UPGRADE_AMOUNT = 2;

    [SerializeField] private int maxHealth;
    [SerializeField] private int health;
    [SerializeField] bool inactivateOnZeroHealth = false;
    private AudioClip hurtSFX;
    private ParticleSystem hurtVFX;
    private AudioClip deathSFX;
    private ParticleSystem deathVFX;

    Action<float> onHealthChanged;

    void Start()
    {
        SetHealth(maxHealth);
    }

    public override void SubscribeHealthChanged(Action<float> action)
    {
        onHealthChanged += action;
    }

    public override void UnsubscribeHealthChanged(Action<float> action)
    {
        onHealthChanged -= action;
    }

    public override void Damage(int hits)
    {
        SetHealth(health - hits);
        if (health <= 0)
        {
            AudioManager.Instance.PlayOneShot(deathSFX);
            
            if (deathVFX)
                Debug.Log("TODO deathVFX");
            
            if (inactivateOnZeroHealth)
                gameObject.SetActive(false);
        }
        else if (hits > 0)
        {
            AudioManager.Instance.PlayOneShot(hurtSFX);
            if (deathVFX)
                Debug.Log("TODO hurtVFX");
        }
    }

    private void SetHealth(int value)
    {
        int newHealth = Mathf.FloorToInt(Mathf.Clamp(value, 0f, maxHealth));
        if (health != newHealth)
        {
            health = newHealth;
            onHealthChanged?.Invoke((health * 1f) / maxHealth);
        }
    }


    public void Init(int maxHealth, AudioClip hurtSFX, ParticleSystem hurtVFX, AudioClip deathSFX, ParticleSystem deathVFX)
    {
        SetMaxHealth(maxHealth);
        this.hurtSFX = hurtSFX;
        this.hurtVFX = hurtVFX;
        this.deathSFX = deathSFX;
        this.deathVFX = deathVFX;
    }


    private void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
        SetHealth(maxHealth);
    }

    override public float GetNormalizedHealth()
    {
        return health / maxHealth;
    }

    public void RestoreHealth()
    {
        SetHealth(maxHealth);
    }

    public void UpgradeMaxHealth()
    {
        maxHealth += MAX_HEALTH_UPGRADE_AMOUNT;
        SetHealth(health + MAX_HEALTH_UPGRADE_AMOUNT);
    }
}
