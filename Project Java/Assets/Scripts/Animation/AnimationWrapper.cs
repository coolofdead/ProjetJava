using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationWrapper : MonoBehaviour
{
    public GameObject UI;
    private Animator[] animators;
    private static AnimationWrapper singleton;

    private void Start()
    {
        animators = transform.GetComponentsInChildren<Animator>();
        if (singleton == null)
            singleton = this;
    }

    public static void StartAnimation(string animatorName, string animationName)
    {
        bool animatorFound = false;
        // use the name of animators gameobjects to find the right animator then play the animation with name ''
        foreach (Animator animator in singleton.animators)
        {
            if (animator.transform.name.ToLower() == animatorName.ToLower())
            {
                animatorFound = true;
                animator.Play(animationName);
            }
        }

        if (!animatorFound)
            Debug.Log(animatorName + " n'a pas été trouvé");
    }

    public static void EnableUI()
    {
        singleton.UI.SetActive(true);
    }
}
