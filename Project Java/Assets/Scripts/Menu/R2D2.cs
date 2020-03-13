using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R2D2 : MonoBehaviour
{
    AudioSource source;
    public AudioClip[] clips;

    public int min = 13;
    public int max = 19;


    Animator animator;
    public AnimationClip[] anims;

    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        Invoke("PlayRandomAnim", Random.Range(min, max));
        Invoke("PlayRandomClip", Random.Range(min, max));
    }

    void PlayRandomAnim()
    {
        var clip = anims[Random.Range(0, anims.Length)];
        animator.Play(clip.name);
        Invoke("PlayRandomAnim", Random.Range(min, max));
    }

    void PlayRandomClip()
    {
        source.clip = clips[Random.Range(0, clips.Length)];
        source.Play();
        Invoke("PlayRandomClip", Random.Range(min, max));
    }
}
