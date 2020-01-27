using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ywing : Vehicle, IDamageable
{
    public float horizontalRotateSpeed = 10f;
    public float rotateForwardSpeed = 90;

    public float rotateSpeed = 130f;
    public float tiltRight;
    public float tiltLeft;
    private float curRot = 0;
    private int life = 3;

    private Shield shield;
    public GameObject[] fireImpacts;
    [SerializeField]
    protected Transform tranformToMove;

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

        tranformToMove.position += tranformToMove.forward * forwardSpeed;
    }

    public override void Act()
    {
        shield.State = !shield.State;
    }

    public override void Move(Vector3 dir)
    {
        Vector3 dist = Vector3.zero;

        if (dir.x != 0)
        {
            int horizontalDir = dir.x > 0 ? 1 : -1;
            tranformToMove.Rotate(tranformToMove.forward * horizontalRotateSpeed * Time.deltaTime * horizontalDir);
        }

        if (dir.y != 0)
        {
            int verticalDir = dir.y > 0 ? 1 : -1;
            tranformToMove.Rotate(tranformToMove.right * rotateForwardSpeed * Time.deltaTime * verticalDir);
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

        tranformToMove.position += dist * horizontalRotateSpeed * Time.deltaTime;
    }

    public void TakeDamage(int amount, bool instantKill = false)
    {
        life -= instantKill ? life : amount;
        for (int i = 0; i < 3 - life; i++)
            fireImpacts[i].SetActive(true);

        if (life <= 0)
        {
            Debug.Log("Player die");
        }
    }
}
