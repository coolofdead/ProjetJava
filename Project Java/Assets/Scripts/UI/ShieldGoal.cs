using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShieldGoal : AbstractGoal
{
    [SerializeField]
    private GameObject[] shields;

    public override void Display()
    {
        int nbShieldDestroyed = shields.Count(shield => !shield.activeSelf);

        text.text = $"Destroy {nbShieldDestroyed} / {shields.Length} Shields";
        text.color = IsCompleted() ? completed : uncompleted;
    }

    public override bool IsCompleted()
    {
        bool isCompleted = shields.All(shield => !shield.activeSelf);

        return isCompleted;
    }
}
