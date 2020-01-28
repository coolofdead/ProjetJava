using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriFighter : Enemy
{
    public Transform canonAnchor;

    protected override void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    protected override void Shoot()
    {
        Instantiate(missilePrefab.gameObject, canonAnchor.position, canonAnchor.rotation);

        StartCoroutine(Reload());
    }
}
