using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TurretGoal : AbstractGoal
{
    public override void Display()
    {
        int nbTurretDestroyed = goalItems.Count(turret => !turret.gameObject.activeSelf);
        int numberToPrint = nbTurretDestroyed > numberRequired ? numberRequired : nbTurretDestroyed;

        text.text = $"Destroy {numberToPrint} / {numberRequired} Turrets";
        text.color = IsCompleted() ? completed : uncompleted;
    }

    public override bool IsCompleted()
    {
        int nbDestroyed = goalItems.Count(turret => !turret.gameObject.activeSelf);

        return nbDestroyed >= numberRequired;
    }
}
