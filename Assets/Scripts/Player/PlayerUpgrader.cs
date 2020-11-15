using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// upgrades a random player attribute. very basic. very random.

public enum Upgrade { Gun, Laser, Missile, Speed, MaxHealth, Repair}
public class PlayerUpgrader : MonoBehaviour
{
    public void AwardRandomUpgrade()
    {
        int numUpgrades = System.Enum.GetValues(typeof(Upgrade)).Length;
        int upgradeNum = Random.Range(0, numUpgrades);
        Upgrade upgrade = (Upgrade)upgradeNum;

        GameManager.Instance.FlashMessage($"You found a {upgrade}!");

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        switch (upgrade)
        {
            case Upgrade.Gun:
                player.GetComponent<PlayerFireController>().UpgradeWeapon(0);
                break;
            case Upgrade.Laser:
                player.GetComponent<PlayerFireController>().UpgradeWeapon(1);
                break;
            case Upgrade.Missile:
                player.GetComponent<PlayerFireController>().UpgradeWeapon(2);
                break;
            case Upgrade.Speed:
                player.GetComponent<PlayerMovementController>().UpgradeSpeed();
                break;
            case Upgrade.MaxHealth:
                player.GetComponent<HealthController>().UpgradeMaxHealth();
                break;
            case Upgrade.Repair:
                player.GetComponent<HealthController>().RestoreHealth();
                break;
        }
    }

}
