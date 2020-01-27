using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Spaceship
{
    public Transform anchorCanon;
    public Missile missilePrefab;

    public void Shoot()
    {
       Instantiate(missilePrefab.gameObject, anchorCanon.position, anchorCanon.rotation);
    }
}
