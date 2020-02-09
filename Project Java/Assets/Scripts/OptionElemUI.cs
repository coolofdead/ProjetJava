using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionElemUI : MonoBehaviour
{
    public enum Type { Son, Quitter, Retour }
    public Type type;

    public Text text;
    private bool status = true;
    public OptionUI optionUI;

    public void Interract()
    {
        if (type == Type.Son)
        {
            status = !status;
            Debug.Log(Camera.main);
            Camera.main.GetComponent<AudioListener>().enabled = status;
            text.text = status ? "activer" : "desactiver";
            text.color = status ? Color.green : Color.red;
        }

        if (type == Type.Quitter)
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }

        if (type == Type.Retour)
        {
            Time.timeScale = 1f;
            optionUI.Disable();
        }
    }
}
