using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public static int level = 1;

    private static IntroManager singleton;
    public LoadingLevel loadingLevel;

    private bool hasPlayerOneSkip = false, hasPlayerTwoSkip = false;

    public Image playerOneSkip, playerTwoSkip;
    public Color skipColor, defaultColor = Color.white;

    private bool levelRunning = false;

    void Awake()
    {
        singleton = this;
    }

    void Update()
    {
        hasPlayerOneSkip = InputManager.GetVirtualInput(InputManager.PlayerTag.Player1).FirstButtonPressed() ? !hasPlayerOneSkip : hasPlayerOneSkip;
        hasPlayerTwoSkip = InputManager.GetVirtualInput(InputManager.PlayerTag.Player2).FirstButtonPressed() ? !hasPlayerTwoSkip : hasPlayerTwoSkip;

        playerOneSkip.color = hasPlayerOneSkip ? skipColor : defaultColor;
        playerTwoSkip.color = hasPlayerTwoSkip ? skipColor : defaultColor;

        if (hasPlayerOneSkip && hasPlayerTwoSkip && !levelRunning) {
            InitLevel();
        }
    }

    public static void InitLevel() 
    {
        singleton.levelRunning = true;
        singleton.StartCoroutine(singleton.loadingLevel.LoadScene("Level 1"));
    }
}
