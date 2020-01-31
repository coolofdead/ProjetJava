using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShieldGoal : AbstractGoal
{
    public override void Display()
    {
        int nbShieldDestroyed = goalItems.Count(shield => !shield.gameObject.activeSelf);
        int numberToPrint = nbShieldDestroyed > numberRequired ? numberRequired : nbShieldDestroyed;

        text.text = $"{numberToPrint} / {numberRequired}";
        text.color = IsCompleted() ? completed : uncompleted;
    }

    public override bool IsCompleted()
    {
        int nbDestroyed = goalItems.Count(shield => !shield.gameObject.activeSelf);

        return nbDestroyed >= numberRequired;
    }
}
