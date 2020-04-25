using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class AbstractGoal : MonoBehaviour
{
    public int numberRequired;
    protected bool isScoreGiven;
    public int score;

    [SerializeField]
    protected Text text;
    public Color completed = Color.green;
    public Color uncompleted = Color.red;

    public enum GoalType { Turret, Shield, Spaceship }
    [SerializeField]
    private GoalType type;
    public GoalType Type { get { return type; } set { type = value; } }

    protected List<GoalItem> goalItems;

    public void SetGameobjectsGoal(List<GoalItem> goalItems)  
    {
        this.goalItems = goalItems;
    }

    public void GetScore()
    {
        if (IsCompleted() && !isScoreGiven)
        {
            isScoreGiven = true;
            Player.player.Score += score;
        }
    }

    public virtual void Notify(GoalItem item) { }
    
    public abstract bool IsCompleted();
    public abstract void Display();
}
