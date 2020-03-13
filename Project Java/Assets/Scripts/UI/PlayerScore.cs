using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        InvokeRepeating("PrintScore", 0, 1f);
    }

    void PrintScore()
    {
        text.text = Player.player.Score.ToString();
    }
}
