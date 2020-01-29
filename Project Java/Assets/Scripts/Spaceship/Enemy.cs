using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Spaceship
{
    public Missile missilePrefab;

    protected override void FaceTarget()
    {
        var targetDirection = target.position - transform.position;
        var targetRotation = Quaternion.LookRotation(targetDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p != null)
            p.TakeDamage(1);
    }
}
