using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GoalItem : MonoBehaviour
{
    public AbstractGoal.GoalType type;

    private void OnTriggerEnter(Collider other)
    {
        Missile m = other.gameObject.GetComponent<Missile>();
        Enemy e = GetComponent<Enemy>();
        if (m != null && e != null)
            if (m.isFromPlayer && e.Life <= 0)
                Goal.NotifyAll(this);

        if (m != null && m.isFromPlayer)
        {
            gameObject.SetActive(false);
        }
    }
}
