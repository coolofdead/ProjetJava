using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriFighter : Enemy
{
    public Transform canonAnchor;
    public float movingStraightDuration = 3f;

    private bool movingStraight;

    protected override void FaceTarget()
    {
        if (movingStraight)
            return;

        var targetDirection = target.position - transform.position;
        var targetRotation = Quaternion.LookRotation(targetDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }

    protected override void Move()
    {
        if (distanceWithTarget < closeDistance && !movingStraight)
            StartCoroutine(MovingStraight());

        transform.position += transform.forward * speed * Time.deltaTime;
    }

    protected override void Shoot()
    {
        shoot.clip = shoots[Random.Range(0, shoots.Length)];
        shoot.Play();

        Instantiate(missilePrefab.gameObject, canonAnchor.position, canonAnchor.rotation);

        StartCoroutine(Reload());
    }

    IEnumerator MovingStraight()
    {
        movingStraight = true;
        var bonusSpeed = speed * 1.5f;
        speed += bonusSpeed;

        yield return new WaitForSeconds(movingStraightDuration);

        movingStraight = false;
        speed -= bonusSpeed;
    }
}
