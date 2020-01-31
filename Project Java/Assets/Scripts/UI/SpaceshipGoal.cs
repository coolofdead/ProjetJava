using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpaceshipGoal : AbstractGoal
{
    private int nbSpaceshipDestroyed;

    public override void Display()
    {
        int numberToPrint = nbSpaceshipDestroyed > numberRequired ? numberRequired : nbSpaceshipDestroyed;

        text.text = $"{numberToPrint} / {numberRequired}";
        text.color = IsCompleted() ? completed : uncompleted;
    }

    public override bool IsCompleted()
    {
        return nbSpaceshipDestroyed >= numberRequired;
    }

    public override void Notify(GoalItem item)
    {
        nbSpaceshipDestroyed++;
    }
}
