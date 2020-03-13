using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShieldDoorLocker : MonoBehaviour
{
    public GameObject doorRight;
    public GameObject doorLeft;

    public GameObject[] frontLockers;
    public GameObject[] backLockers;

    private void OnTriggerEnter(Collider other)
    {
        Missile m = other.GetComponent<Missile>();
        if (m == null)
            return;

        if (m.isFromPlayer)
        {
            gameObject.SetActive(false);

            var front = frontLockers.Count(door => !door.activeSelf);
            var back = backLockers.Count(door => !door.activeSelf);

            if (back == 2 || front == 2)
            {
                doorLeft.SetActive(false);
                doorRight.SetActive(false);
            }
        }
    }
}
