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

    private VirtualInput vInput;

    private bool axisIsOnCd;
    public float axisDelay = 0.2f;

    void Start()
    {
        planets = holoMap.GetComponentsInChildren<LevelPlanet>();

        for (int i=0; i < planets.Length; i++)
        {
            planets[i].SetMeshState(maxLevelReached >= i ? enablePlanet : disablePlanet);
        }

        vInput = InputManager.GetVirtualInput(InputManager.PlayerTag.Player1);
    }

    void Update()
    {
        var inputAxis = vInput.GetAxis();

        if (inputAxis.x != 0 && !axisIsOnCd)
        {
            StartCoroutine(AxisDelay());

            planets[cursor].transform.localScale /= 2;

            cursor += inputAxis.x < 0 ? -1 : 1;
            if (cursor < 0) cursor = planets.Length - 1;
            if (cursor == planets.Length) cursor = 0;
            SetCurrentLevel(planets[cursor]);
        }

        if (vInput.FirstButtonPressed())
        {
            if (maxLevelReached >= cursor)
            {
                IntroManager.level = cursor + 1;
                SceneManager.LoadScene("Intro", LoadSceneMode.Single);
                Destroy(gameObject);
            }
        }
    }

    public void SetCurrentLevel (LevelPlanet levelSelected)
    {
        levelSelected.transform.localScale *= 2;

        menu.UpdateLevel(levelSelected);
    }

    private IEnumerator AxisDelay()
    {
        axisIsOnCd = true;

        yield return new WaitForSeconds(axisDelay);

        axisIsOnCd = false;
    }
}
