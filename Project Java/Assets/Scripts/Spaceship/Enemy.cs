using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Spaceship
{
    public Missile missilePrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p != null)
            p.TakeDamage(10);
    }
}
