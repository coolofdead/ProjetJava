using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Allied : Spaceship
{
    public Missile missilePrefab;
    public float runAwayDuration = 7f;
    protected Vector3 runDir;
    protected bool isRunningAway;

    protected override void FaceTarget()
    {
        var targetDirection = target.position - transform.position;
        var targetRotation = Quaternion.LookRotation(targetDirection);

        var rotation = isRunningAway ? Quaternion.Euler(runDir) : target.rotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }

    public override void TakeDamage(int amount, bool instantKill = false)
    {
        base.TakeDamage(amount, instantKill);

        StartCoroutine(RunAway());
    }

    protected IEnumerator RunAway()
    {
        runDir = Random.onUnitSphere;
        isRunningAway = true;

        yield return new WaitForSeconds(runAwayDuration);

        isRunningAway = false;
    }
}
