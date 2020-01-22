using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ywing : Vehicle, IDamageable
{
    public float maxWidth = 8f;
    public float minWidth = -8f;
    public float maxHeight = 4.5f;
    public float minHeight = -6f;

    public float speed = 10f;
    public float rotateSpeed = 30f;
    public float autoStableSpeed = 0.5f;

    public float tiltRight;
    public float tiltLeft;

    private int life = 3;
    public Shield shield;

    public GameObject[] fireImpacts;

    protected override void Update()
    {
        base.Update();
    }

    public override void Act()
    {
        shield.State = !shield.State;
    }

    public override void Move(Vector3 dir)
    {
        Vector3 dist = Vector3.zero;
        Vector3 transformPos = transform.TransformPoint(transform.position);

        if (transformPos.x > maxWidth && dir.x > 0)
        {
            dist += transform.right;
            dist.y = 0;
        }

        if (transformPos.x < minWidth && dir.x < 0)
        {
            dist += -transform.right;
            dist.y = 0;
        }

        if (transformPos.y < maxHeight && dir.y > 0)
        {
            dist += transform.up;
        }

        if (transformPos.y > minHeight && dir.y < 0)
        {
            dist += -transform.up;
        }

        if (dir.x == 0)
        {
            if (transform.rotation.x > 0.01f)
            {
                transform.Rotate(Vector3.forward, -rotateSpeed * autoStableSpeed * Time.deltaTime);
            }
            if (transform.rotation.x < 0.01f)
            {
                transform.Rotate(Vector3.forward, rotateSpeed * autoStableSpeed * Time.deltaTime);
            }
        }

        if (dir.x > 0 && transform.rotation.x > tiltRight || dir.x < 0 && transform.rotation.x < tiltLeft)
        {
            int tiltDir = dir.x > 0 ? -1 : 1;
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime * tiltDir);
        }

        transform.position += dist * speed * Time.deltaTime;
    }

    public void TakeDamage(int amount, bool instantKill = false)
    {
        life -= amount;
        for (int i = 0; i < 3 - life; i++)
            fireImpacts[i].SetActive(true);

        if (life <= 0 || instantKill)
        {
            Debug.Log("Player die");
        }
    }
}
