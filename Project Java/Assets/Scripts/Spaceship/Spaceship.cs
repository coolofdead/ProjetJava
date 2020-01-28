using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spaceship : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected float life;
    public float maxSpeed = 8;
    protected float speed = 8;

    public float rotateSpeed = 5f;
    public float angleShot = 5f;
    public float shotRange = 100f;
    public float reloadTime = 1.2f;
    protected bool isReloading = false;

    protected Transform target;
    public Transform Target { get { return target; } }

    protected const float CLOSE_RANGE = 90f;

    protected virtual void Update()
    {
        if (target == null)
        {
            SpaceshipManager.SetSpaceshipTarget(this);
            return;
        }

        var distanceWithTarget = Vector3.Distance(transform.position, target.position);
        if (distanceWithTarget <= shotRange
            && Vector3.Angle(transform.forward, target.position - transform.position) < angleShot
            && !isReloading)
        {
            Shoot();
        }

        speed = Mathf.Lerp(maxSpeed * 0.1f, maxSpeed, distanceWithTarget / shotRange);
        FaceTarget();
        Move();
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected abstract void Move();
    protected abstract void Shoot();
    protected abstract void FaceTarget();

    public virtual void TakeDamage(int amount, bool instantKill = false)
    {
        life -= instantKill ? life : amount;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime + Random.Range(0, reloadTime));
        isReloading = false;
    }
}
