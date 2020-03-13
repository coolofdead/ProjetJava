using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IDamageable
{
    [SerializeField]
    private MeshRenderer mr;
    [SerializeField]
    private Collider c;

    private int life;
    public int maxLife = 1;
    private float actifTimeLeft;
    public float ActifTimeLeft { get { return actifTimeLeft; } }
    private bool isRecovering;
    public bool IsRecovering { get { return isRecovering; } }
    public float recoveryTime = 8;
    public float recoveryTimeOverSec = 0.2f;
    private bool state;
    public bool State
    {
        get { return state; }
        set
        {
            if (value && life <= 0 || value && isRecovering)
                return;

            StopAllCoroutines();
            isRecovering = false;

            state = value; 
            mr.enabled = value;
            c.enabled = value;
        }
    }

    private void Start()
    {
        State = false;
        actifTimeLeft = recoveryTime;
        life = maxLife;
    }

    private void Update()
    {
        if (State)
        {
            actifTimeLeft -= Time.deltaTime;
            if (actifTimeLeft <= 0)
            {
                actifTimeLeft = 0;
                State = false;
                StartCoroutine(RegeneratingShield());
            }
        }

        if (!State && life > 0 && !isRecovering)
        {
            actifTimeLeft += recoveryTimeOverSec * Time.deltaTime;
            if (actifTimeLeft > recoveryTime)
                actifTimeLeft = recoveryTime;
        }
    }

    public void TakeDamage(int amount, bool instantKill = false)
    {
        if (instantKill)
            life = 0;

        life -= amount;
        if (life <= 0)
        {
            State = false;
            actifTimeLeft = 0;
            StartCoroutine(RegeneratingShield());
        }
    }

    IEnumerator RegeneratingShield()
    {
        isRecovering = true;
        while (actifTimeLeft < recoveryTime)
        {
            yield return new WaitForEndOfFrame();
            actifTimeLeft += Time.deltaTime;
            if (actifTimeLeft > recoveryTime)
                actifTimeLeft = recoveryTime;
        }
        life = maxLife;
        isRecovering = false;
    }
}
