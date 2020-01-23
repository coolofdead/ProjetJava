using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EventAnimation : MonoBehaviour
{
    private const char stringSeparator = '-';

    public void TriggerAnimation(string animatorAndAnimationName)
    {   
        string animatorName = animatorAndAnimationName.Split(stringSeparator)[0];
        string animationName = animatorAndAnimationName.Split(stringSeparator)[1];

        Debug.Log(animatorName + " / " + animationName);

        AnimationWrapper.StartAnimation(animatorName, animationName);
    }
}