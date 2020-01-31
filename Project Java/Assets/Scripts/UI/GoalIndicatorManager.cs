using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalIndicatorManager : MonoBehaviour
{
    public static GoalIndicatorManager singleton;
    public GoalIndicator enemyIndicator;

    private void Start()
    {
        if (singleton == null)
            singleton = this;
    }

    public static void SetEnemyReference(Transform enemy)
    {
        singleton.enemyIndicator.reference = enemy;
    }
}
