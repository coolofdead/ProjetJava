using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public Intro[] intros;
    public Text story;

    public static int level = 1;

    void Start()
    {
        story.text = intros[level-1].levelStory;
    }
}
