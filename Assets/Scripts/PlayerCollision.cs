using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthController))]
public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GetComponent<HealthController>().Damage(99);
            other.gameObject.SetActive(false); // TODO Kill enemy on collision?  Score? Allow to survive?
        }
    }
}
