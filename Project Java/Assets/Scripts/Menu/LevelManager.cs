using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int maxLevelReached = 0;

    public MenuUI menu;
    public Transform holoMap;
    private LevelPlanet[] planets;
    private int cursor;

    public Material enablePlanet;
    public Material disablePlanet;

    void Start()
    {
        planets = holoMap.GetComponentsInChildren<LevelPlanet>();

        for (int i=0; i < planets.Length; i++)
        {
            planets[i].SetMeshState(maxLevelReached >= i ? enablePlanet : disablePlanet);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            planets[cursor].transform.localScale /= 2;

            cursor += Input.GetKeyDown(KeyCode.LeftArrow) ? -1 : 1;
            if (cursor < 0) cursor = planets.Length - 1;
            if (cursor == planets.Length) cursor = 0;
            SetCurrentLevel(planets[cursor]);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (maxLevelReached >= cursor)
            {
                IntroManager.level = cursor + 1;
                SceneManager.LoadScene("Intro", LoadSceneMode.Single);
            }
        }
    }

    public void SetCurrentLevel (LevelPlanet levelSelected)
    {
        levelSelected.transform.localScale *= 2;

        menu.UpdateLevel(levelSelected);
    }
}
