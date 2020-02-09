using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroUI : MonoBehaviour
{
    public Animator missionDescription;
    public LoadingLevel loadingLevel;

    public void DiplsayMissionDescription()
    {
        missionDescription.gameObject.SetActive(true);
        missionDescription.Play("Level " + IntroManager.level);
    }

    public void InitLevel()
    {
        StartCoroutine(loadingLevel.LoadScene("Level " + IntroManager.level));
    }

    public void StartCameraAnimation()
    {
        Camera.main.GetComponent<Animator>().enabled = true;
    }
}
