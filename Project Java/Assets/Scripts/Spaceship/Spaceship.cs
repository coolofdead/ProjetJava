using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spaceship : MonoBehaviour, IDamageable
{
    public int score;

    public int maxLife;
    protected int life;
    public int Life { get { return life; } }
    public float speed = 8;

    public float rotateSpeed = 5f;
    public float angleShot = 5f;
    public float shotRange = 100f;
    public float reloadTime = 1.2f;
    protected bool isReloading = false;

    protected Transform target;
    public Transform Target { get { return target; } }

    protected float closeDistance = 90f;
    protected float distanceWithTarget;

    void Start()
    {
        closeDistance = shotRange / 2;
        life = maxLife;
    }

    protected virtual void Update()
    {
        if (OptionUI.isPaused)
            return;

        if (target == null)
        {
            SpaceshipManager.SetSpaceshipTarget(this);
            return;
        }

        distanceWithTarget = Vector3.Distance(transform.position, target.position);
        if (distanceWithTarget <= shotRange
            && Vector3.Angle(transform.forward, target.position - transform.position) < angleShot
            && !isReloading)
        {
            Shoot();
        }

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
            if (this is Enemy)
                Player.player.Score += score;
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
