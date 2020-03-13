using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    public static bool isPaused = false;

    public RectTransform cursor;
    public OptionElemUI[] elems;

    public GameObject optionMenu;

    private Vehicle playerKing;
    private int cursorIndex = 0;
    private bool isDelay = false;

    void Start()
    {
        cursor.position = elems[0].transform.position;
    }

    void Update()
    {
        if (!Player.player.player1.enabled || !Player.player.player2.enabled)
            return;

        if(Player.player.player1.VInput.SecondButtonPressed() && !optionMenu.activeSelf || 
           Player.player.player2.VInput.SecondButtonPressed() && !optionMenu.activeSelf)
        {
            playerKing = Player.player.player1.VInput.SecondButtonPressed() ? Player.player.player1 : Player.player.player2;
            optionMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }

        if (optionMenu.activeSelf)
        {
            float dir = playerKing.VInput.GetAxis().x;
            if (dir > 0 && cursorIndex + 1 < elems.Length && !isDelay)
            {
                StartCoroutine(DelayMoveUI());
                cursorIndex++;
                cursor.transform.position = elems[cursorIndex].transform.position;
            }
            if (dir < 0 && cursorIndex > 0 && !isDelay)
            {
                StartCoroutine(DelayMoveUI());
                cursorIndex--;
                cursor.transform.position = elems[cursorIndex].transform.position;
            }

            if (playerKing.VInput.FirstButtonPressed())
            {
                elems[cursorIndex].Interract();
            }
        }
    }

    public void Disable()
    {
        cursorIndex = 0;
        cursor.position = elems[cursorIndex].transform.position;
        playerKing = null;
        optionMenu.SetActive(false);
        isPaused = false;
    }

    IEnumerator DelayMoveUI()
    {
        isDelay = true;
        yield return new WaitForSecondsRealtime(0.2f);
        isDelay = false;
    }
}
