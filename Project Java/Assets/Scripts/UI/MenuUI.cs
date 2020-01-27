using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Text levelName;

    public void UpdateLevel(LevelPlanet level)
    {
        levelName.text = level.levelName;
    }
}
