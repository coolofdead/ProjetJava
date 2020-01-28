using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunship : Allied
{
    public float distanceFromAlly = 100f;
    public Transform leftCanon;
    public Transform rightCanon;

    private Spaceship targetSpaceship;

    protected override void Move()
    {
        var isCloseRangeWithTarget = Vector3.Distance(transform.position, target.position) <= CLOSE_RANGE;
        if (isCloseRangeWithTarget && !isRunningAway)
        {
            StartCoroutine(RunAway());
        }

        var dir = isRunningAway ? runDir : transform.forward;

        transform.position += dir * speed * Time.deltaTime;
    }

    protected override void FaceTarget()
    {
        if (Vector3.Distance(transform.position, targetSpaceship.Target.position) > distanceFromAlly && !isRunningAway)
        {
            var targetDirection = targetSpaceship.Target.position - transform.position;
            var targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
        else
        {
            var rotation = isRunningAway ? Quaternion.Euler(runDir) : targetSpaceship.Target.rotation;

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        }
    }

    protected override void Shoot()
    {
        var canonTransfomr = target.position.x > transform.position.x ? rightCanon : leftCanon;
        Instantiate(missilePrefab.gameObject, canonTransfomr.position, canonTransfomr.rotation);

        StartCoroutine(Reload());
    }

    public override void SetTarget(Transform target)
    {
        base.SetTarget(target);
        targetSpaceship = target.GetComponent<Spaceship>();
    }
}
