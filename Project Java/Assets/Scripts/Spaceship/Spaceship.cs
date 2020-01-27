using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spaceship : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected float life;

    protected Transform target;

    protected void Update()
    {
        if (target == null)
        {
            SpaceshipManager.SetSpaceshipTarget(this);
        }
        else
        {
            Move();
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected abstract void Move();

    public virtual void TakeDamage(int amount, bool instantKill = false)
    {
        life -= instantKill ? life : amount;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
