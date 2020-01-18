using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 90;

    void Update()
    {
        transform.Rotate(transform.up * speed * Time.deltaTime);
    }
}
