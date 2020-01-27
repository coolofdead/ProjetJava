using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class AbstractGoal : MonoBehaviour
{
    [SerializeField]
    protected Text text;
    public Color completed = Color.green;
    public Color uncompleted = Color.red;

    public abstract bool IsCompleted();

    public abstract void Display();
}
