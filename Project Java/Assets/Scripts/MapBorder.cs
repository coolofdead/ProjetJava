using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBorder : MonoBehaviour
{
    private Vector3 teleportationPos = new Vector3(-107, 680, -27381);

    private void OnCollisionEnter(Collision collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p != null) {
            p.transform.position = teleportationPos;
        }
    }
}
