using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpaceshipGoal : AbstractGoal
{
    [SerializeField]
    private GameObject[] spaceships;

    public override void Display()
    {
        int nbSpaceshipsDestroyed = spaceships.Count(spaceship => !spaceship.activeSelf);

        text.text = $"Destroy {nbSpaceshipsDestroyed} / {spaceships.Length} Spaceships";
        text.color = IsCompleted() ? completed : uncompleted;
    }

    public override bool IsCompleted()
    {
        bool isCompleted = spaceships.All(spaceship => !spaceship.activeSelf);

        return isCompleted;
    }
}
