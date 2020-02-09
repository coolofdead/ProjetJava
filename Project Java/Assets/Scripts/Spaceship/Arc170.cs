using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arc170 : Allied
{
    public Transform[] anchorCanons;

    protected override void Move()
    {
        var isCloseRangeWithTarget = Vector3.Distance(transform.position, target.position) <= closeDistance;
        if (isCloseRangeWithTarget && !isRunningAway)
        {
            StartCoroutine(RunAway());
        }

        var dir = isRunningAway ? runDir : transform.forward;

        transform.position += dir * speed * Time.deltaTime;
    }

    protected override void Shoot()
    {
        foreach(Transform canonAnchor in anchorCanons)
        {
            Instantiate(missilePrefab.gameObject, canonAnchor.position, canonAnchor.rotation);
        }

        StartCoroutine(Reload());
    }
}
