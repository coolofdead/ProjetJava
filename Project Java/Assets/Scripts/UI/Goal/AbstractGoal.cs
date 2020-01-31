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
    public GoalType Type { get { return type; } }

    protected List<GoalItem> goalItems;

    protected void Update()
    {
        if (IsCompleted() && !isScoreGiven)
        {
            isScoreGiven = true;
            Player.player.Score += score;
        }
    }

    public void SetGameobjectsGoal(List<GoalItem> goalItems)  
    {
        this.goalItems = goalItems;
    }

    public virtual void Notify(GoalItem item) { }
    
    public abstract bool IsCompleted();
    public abstract void Display();
}
