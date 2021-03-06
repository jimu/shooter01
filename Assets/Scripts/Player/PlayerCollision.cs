﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// deals with the player colliding with bonuses and enemies.
// see projectiles for player-projectile damage

[RequireComponent(typeof(HealthController))]
public class PlayerCollision : MonoBehaviour
{
    static readonly int SCORE_DROP_POINTS = 2;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Enemy":
            case "DangerDrop":
                GetComponent<HealthController>().Damage(99);
                break;
            case "ScoreDrop":
                GameManager.Instance.AddScore(SCORE_DROP_POINTS);
                break;
            case "UpgradeDrop":
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUpgrader>().AwardRandomUpgrade();
                break;
            default:
                return;
        }
        other.gameObject.SetActive(false);

    }
}
