using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HighscoreBoard : MonoBehaviour
{
    public InputField input;

    public GameObject info;
    public GameObject leadboard;

    public Text bestPlayers;

    private const string ENDPOINT = "http://localhost:8080";

    public void SaveScore()
    {
        StartCoroutine(SaveScore(input.text, Player.player.Score));
    }

    public IEnumerator GetHighscore()
    {
        UnityWebRequest uwr = UnityWebRequest.Get(ENDPOINT + "/AllScore.php");
        yield return uwr.SendWebRequest();

        if (!uwr.isNetworkError)
        {
            string json = "{\"scores\":" + uwr.downloadHandler.text + "}";

            Dashboard dashboard = JsonUtility.FromJson<Dashboard>(json);

            info.SetActive(false);
            leadboard.SetActive(true);

            foreach (Score s in dashboard.scores)
            {
                bestPlayers.text += s.pseudo + " : " + s.score + "\n";
            }
        }
        else
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
    }

    public IEnumerator SaveScore(string pseudo, int score)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(ENDPOINT + "/InsertScore.php?pseudo=" + pseudo+"&score="+score);
        yield return uwr.SendWebRequest();

        StartCoroutine(GetHighscore());
    }

    [Serializable]
    public class Dashboard
    {
        public List<Score> scores;

        public Dashboard(List<Score> scores)
        {
            this.scores = scores;
        }
    }

    [Serializable]
    public class Score
    {
        public string pseudo;
        public int score;

        public Score(string pseudo, int score)
        {
            this.pseudo = pseudo;
            this.score = score;
        }
    }
}
