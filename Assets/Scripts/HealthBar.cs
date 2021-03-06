﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649


/**
 * Implements a gradient colored health bar for enemies and the player
 */

public class HealthBar : MonoBehaviour
{
    public Gradient gradient;

    private Slider slider;
    private Image fill;
    [SerializeField] MonoDamagable owner;


    private void OnEnable()
    {
        owner.SubscribeHealthChanged(OnHitsChanged);
        slider = GetComponent<Slider>();
        fill = transform.Find("Fill").GetComponent<Image>();
        OnHitsChanged(owner.GetNormalizedHealth());
    }

    private void OnDisable()
    {
        owner.UnsubscribeHealthChanged(OnHitsChanged);
    }

    void OnHitsChanged(float percent)
    {
        slider.value = percent;
        fill.color = gradient.Evaluate(percent);
    }
}
