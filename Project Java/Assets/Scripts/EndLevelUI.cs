using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevelUI : MonoBehaviour
{
    public Text text;
    public Text time;
    public Text score;
    public GameObject endLevel;

    public Button validate;

    private void Start()
    {
        DisplayEndLevelScreen(!Player.victory);
    }

    public void DisplayEndLevelScreen(bool playerDied)
    {
        int min = (int)(Time.time / 60);

        validate.GetComponent<Image>().color = playerDied ? Color.red : Color.yellow;
        score.text = "Score : " + Player.player.Score.ToString();
        endLevel.SetActive(true);
        time.text = min.ToString("0") + ":" + (Time.time - min * 60).ToString("0.00").Replace(',', ':');
        text.text = playerDied ? "defaite" : "victory";
        text.color = playerDied ? Color.red : Color.yellow;
    }
}
