using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ywing : Vehicle, IDamageable
{
    public float speed = 10f;
    public float rotateSpeed = 130f;

    public float tiltRight;
    public float tiltLeft;

    private float curRot = 0;

    private int life = 3;
    private Shield shield;

    public GameObject[] fireImpacts;

    protected override void Update()
    {
        base.Update();

        if (forwardSpeed < maxForwardSpeed && curRot == 0)
        {
            forwardSpeed += acceleration * Time.deltaTime;
        }
        else if (curRot != 0)
        {
            forwardSpeed -= decelaration * Time.deltaTime;
            if (forwardSpeed < minForwardSpeed)
                forwardSpeed = minForwardSpeed;
        }
    }

    public override void Act()
    {
        shield.State = !shield.State;
    }

    public override void Move(Vector3 dir)
    {
        Vector3 dist = Vector3.zero;
        Vector3 transformPos = transform.TransformPoint(transform.position);

        if (dir.x > 0)
        {
            dist += transform.right;
            dist.y = 0;
        }

        if (dir.x < 0)
        {
            dist += -transform.right;
            dist.y = 0;
        }

        if (dir.y > 0)
        {
            dist += transform.up;
        }

        if (dir.y < 0)
        {
            dist += -transform.up;
        }

        if (dir.x == 0)
        {
            if (curRot > 0)
            {
                curRot--;
                transform.Rotate(Vector3.forward, rotateSpeed * 0.016f);
            }
            if (curRot < 0)
            {
                curRot++;
                transform.Rotate(Vector3.forward, -rotateSpeed * 0.016f);
            }
        }

        if (dir.x > 0 && curRot < tiltRight || dir.x < 0 && curRot > tiltLeft)
        {
            int tiltDir = dir.x > 0 ? -1 : 1;
            curRot += dir.x > 0 ? 1 : -1;
            transform.Rotate(Vector3.forward, (rotateSpeed * tiltDir) * 0.016f);
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
