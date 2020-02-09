using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalIndicatorManager : MonoBehaviour
{
    public static GoalIndicatorManager singleton;
    public GoalIndicator enemyIndicator;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
    }

    public static void SetEnemyReference(Enemy enemy)
    {
        singleton.enemyIndicator.reference = enemy;
    }
}
