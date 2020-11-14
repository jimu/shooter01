using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    HealthController healthController;

    void Awake()
    {
        healthController = GetComponent<HealthController>();
        healthController.SubscribeHealthChanged(CheckForDeath);
    }

    private void OnDisable()
    {

        healthController.UnsubscribeHealthChanged(CheckForDeath);

    }
    void CheckForDeath(float normalizedHealth)
    {
        Debug.Log($"CheckForDeath({normalizedHealth}");
        if (normalizedHealth <= 0f)
        {
            GameManager.Instance.Lose();
        }
    }
}
