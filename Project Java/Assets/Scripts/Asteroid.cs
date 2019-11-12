using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.tag == "Player")
        {
            Debug.Log("PLAYER DESTROY");
        }
    }
}
