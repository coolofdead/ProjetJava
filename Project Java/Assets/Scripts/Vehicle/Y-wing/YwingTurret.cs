using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YwingTurret : Vehicle
{
    public GameObject missilePrefab;
    public Transform canonDroit, canonGauche;
    public float rotateSpeed = 90, shotInterval;

    private bool isOddSide = false, isReloading;

    AudioSource shoot;

    protected override void Start()
    {
        base.Start();
        shoot = GetComponent<AudioSource>();
    }

    protected override void Update()
    {
        if (OptionUI.isPaused)
            return;

        if (vInput.FirstButton())
        {
            Act();
        }

        Move(vInput.GetAxis());
    }

    public override void Act()
    {
        if (isReloading)
            return;

        Transform canonAnchor = isOddSide ? canonDroit : canonGauche;
        GameObject g = Instantiate(missilePrefab, canonAnchor.position, Quaternion.identity);
        g.transform.LookAt(canonAnchor.position + canonAnchor.forward);
        g.GetComponent<Missile>().isFromPlayer = true;

        isOddSide = !isOddSide;

        shoot.Play();

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
