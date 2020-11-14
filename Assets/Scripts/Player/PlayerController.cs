using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    HealthController healthController;
    public PlayerData data;
    int lives;

    void Awake()
    {
        healthController = GetComponent<HealthController>();
        healthController.SubscribeHealthChanged(CheckForDeath);
        healthController.Init(data.health, data.hurtSFX, data.hurtVFX, data.destroyedSFX, data.destroyedVFX);
        SetLives(data.lives);
    }

    private void OnDisable()
    {
        healthController.UnsubscribeHealthChanged(CheckForDeath);
    }

    void SetLives(int value)
    {
        lives = value;
        GameManager.Instance.SetLives(lives);
    }

    void CheckForDeath(float normalizedHealth)
    {
        if (normalizedHealth <= 0f)
        {
            SetLives(lives - 1);

            if (lives > 0)
            {
                // TODO randomly appear somewhere else
                // reset health
                healthController.RestoreHealth();
            }
        }
    }
}
