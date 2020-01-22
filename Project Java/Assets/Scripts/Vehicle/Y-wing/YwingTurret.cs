using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YwingTurret : Vehicle
{
    public GameObject missilePrefab;
    public Transform canonDroit;
    public Transform canonGauche;
    public float rotateSpeed = 90;
    public float shotInterval;
    private bool isReloading;

    private bool isOddSide;

    public override void Act()
    {
        if (isReloading)
            return;

        Transform canonAnchor = isOddSide ? canonDroit : canonGauche;
        Instantiate(missilePrefab, canonAnchor.position, Quaternion.identity).transform.LookAt(canonAnchor.position + canonAnchor.forward);

        isOddSide = !isOddSide;

        StartCoroutine(Reloading());
    }

    public override void Move(Vector3 dir)
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * dir.x * -1);
    }

    IEnumerator Reloading()
    {
        isReloading = true;
        yield return new WaitForSeconds(shotInterval);
        isReloading = false;
    }
}
