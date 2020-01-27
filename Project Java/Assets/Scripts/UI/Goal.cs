using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Goal : MonoBehaviour
{
    public AbstractGoal [] goals;

    private void Start()
    {
        InvokeRepeating("UpdateGoals", 0f, 3f);
    }

    public void UpdateGoals()
    {
        foreach (AbstractGoal goal in goals)
            goal.Display();

        bool allGoalCompleted = goals.All(goal => goal.IsCompleted());

        if (allGoalCompleted)
        {
            Debug.Log("End of level");
        }
    }
}
