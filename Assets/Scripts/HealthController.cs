using System;
using UnityEngine;

// Sets objects health, accepts damage, notifies subscribers of health change

public class HealthController : MonoDamagable
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health;

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
    }

    public void SetHealth(int value)
    {
        int newHealth = Mathf.FloorToInt(Mathf.Clamp(value, 0f, maxHealth));
        if (health != newHealth)
        {
            health = newHealth;
            onHealthChanged?.Invoke((health * 1f) / maxHealth);
        }
    }

    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
        SetHealth(maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{name} collieded with {other.name}");
    }


}
