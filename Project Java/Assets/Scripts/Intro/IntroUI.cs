using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroUI : MonoBehaviour
{
    public Animator missionDescription;

    public void DiplsayMissionDescription()
    {
        missionDescription.gameObject.SetActive(true);
        missionDescription.Play("Level " + IntroManager.level);
    }

    public void InitLevel()
    {
        IntroManager.InitLevel();
    }

    public void StartCameraAnimation()
    {
        Camera.main.GetComponent<Animator>().enabled = true;
    }
}
