using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TurretGoal : AbstractGoal
{
    [SerializeField]
    private GameObject[] turrets;

    public override void Display()
    {
        int nbTurretDestroyed = turrets.Count(turret => !turret.activeSelf);

        text.text = $"Destroy {nbTurretDestroyed} / {turrets.Length} Turrets";
        text.color = IsCompleted() ? completed : uncompleted;
    }

    public override bool IsCompleted()
    {
        bool isCompleted = turrets.All(turret => !turret.activeSelf);

        return isCompleted;
    }
}
