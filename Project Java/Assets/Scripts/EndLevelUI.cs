using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevelUI : MonoBehaviour
{
    public Text text;
    public Text time;
    public GameObject endLevel;

    public Button validate;

    private static EndLevelUI singleton;

    private void Start()
    {
        if (singleton == null)
            singleton = this;
    }

    public static void DisplayEndLevelScreen(bool playerDied)
    {
        int min = (int)(Time.time / 60);

        singleton.validate.GetComponent<Image>().color = playerDied ? Color.red : Color.yellow;
        singleton.endLevel.SetActive(true);
        singleton.time.text = min.ToString("0") + ":" + (Time.time - min * 60).ToString("0.00").Replace(',', ':');
        singleton.text.text = playerDied ? "defaite" : "victory";
        singleton.text.color = playerDied ? Color.red : Color.yellow;
        Time.timeScale = 0f;
    }
}
