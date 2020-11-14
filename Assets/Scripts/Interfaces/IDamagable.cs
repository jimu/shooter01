using System;
using UnityEngine;
using UnityEngine.UI;

interface IDamagable
{
    void SubscribeHealthChanged(Action<float> action);
    void UnsubscribeHealthChanged(Action<float> action);

    void Damage(int hits);
}


public abstract class MonoDamagable : MonoBehaviour, IDamagable
{
    abstract public void SubscribeHealthChanged(Action<float> action);
    abstract public void UnsubscribeHealthChanged(Action<float> action);
    abstract public void Damage(int hits);
    abstract public float GetNormalizedHealth();
}