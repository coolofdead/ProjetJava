using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : MonoBehaviour
{
    public Animator missionDescription;

    public void DiplsayMissionDescription()
    {
        missionDescription.gameObject.SetActive(true);
    }

    public void InitLevel()
    {
        missionDescription.gameObject.SetActive(false);
    }
}
