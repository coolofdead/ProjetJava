using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    public ParticleSystem trace;

    private void Start()
    {
        trace.Play();
    }

    void Update()
    {
        this.transform.position += this.transform.forward * speed * Time.deltaTime;
    }
}
