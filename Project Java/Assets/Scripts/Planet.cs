using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float speed;

    void Update()
    {
        this.transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
