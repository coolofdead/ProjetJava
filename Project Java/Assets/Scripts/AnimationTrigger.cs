using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public Animator animator;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.enabled = true;
        }
    }
}
