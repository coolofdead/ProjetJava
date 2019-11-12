using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float life;
    public Transform anchorCanon;
    public GameObject missilePrefab;

    public void Shoot()
    {
       Instantiate(missilePrefab, anchorCanon.position, anchorCanon.rotation);
    }

    public void TakeDamage(float amout)
    {
        this.life -= amout;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
