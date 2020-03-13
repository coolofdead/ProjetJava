using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour, IDamageable
{
    public void TakeDamage(int amount, bool instantKill = false)
    {
        gameObject.SetActive(false);
    }
}
