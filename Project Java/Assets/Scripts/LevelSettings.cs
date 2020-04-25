using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LevelSettings : MonoBehaviour
{
    public Goal goalManager;

    private const string ENDPOINT = "http://localhost:8080";

    public void Start()
    {
        StartCoroutine(LoadGoalSettings());
    }

    IEnumerator LoadGoalSettings()
    {
        GoalSetting goalSetting = new GoalSetting();

        UnityWebRequest uwr = UnityWebRequest.Get(ENDPOINT + "/LevelSettings.php?level_id=" + IntroManager.level);

        yield return uwr.SendWebRequest();

        if (!uwr.isNetworkError)
        {
            string json = uwr.downloadHandler.text;

            try
            {
                goalSetting = JsonUtility.FromJson<GoalSetting>(json);
                foreach (AbstractGoal goal in goalManager.goals)
                {
                    if (goal.Type == AbstractGoal.GoalType.Turret)
                    {
                        goal.numberRequired = goalSetting.turret_goal;
                    }

                    if (goal.Type == AbstractGoal.GoalType.Spaceship)
                    {
                        goal.numberRequired = goalSetting.spaceship_goal;
                    }
                }
                
            }
            catch (Exception e)
            {

            }
        }
        else
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
    }

}
