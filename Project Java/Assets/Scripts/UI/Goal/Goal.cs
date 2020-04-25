using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Goal : MonoBehaviour
{
    public AbstractGoal [] goals;
    private static Goal singleton;

    private void Start()
    {
        if (singleton == null)
            singleton = this;

        InvokeRepeating("UpdateGoals", 0f, 1f);

        GoalItem[] items = FindObjectsOfType<GoalItem>();
        foreach (AbstractGoal goal in goals)
            goal.SetGameobjectsGoal(items.ToList().FindAll(item => item.type == goal.Type));
    }

    public void UpdateGoals()
    {
        foreach (AbstractGoal goal in goals)
        {
            goal.Display();
            goal.GetScore();
        }

        bool allGoalCompleted = goals.All(goal => goal.IsCompleted());

        if (allGoalCompleted)
        {
            Player.victory = true;
            SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
        }
    }

    public static void NotifyAll(GoalItem item)
    {
        foreach (AbstractGoal goal in singleton.goals)
            if (goal.Type == item.type)
                goal.Notify(item);
    }
}
