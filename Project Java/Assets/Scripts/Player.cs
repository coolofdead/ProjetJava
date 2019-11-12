using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform canonDroit;
    public Transform canonGauche;

    public GameObject missilePrefab;

    public GameObject vaisseau;

    public float maxWidth = 8f;
    public float minWidth = -8f;
    public float maxHeight = 4.5f;
    public float minHeight = -6f;

    public float speed = 10f;
    public float rotationSpeed = 30f;
    public float autoStableSpeed = 0.5f;

    public float tiltRight;
    public float tiltlLeft;

    public float life = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(missilePrefab, canonDroit.position, Quaternion.identity).transform.LookAt(canonDroit.position + canonDroit.forward);
            Instantiate(missilePrefab, canonGauche.position, Quaternion.identity).transform.LookAt(canonGauche.position + canonGauche.forward);
        }

        Vector3 dir = Vector3.zero;
        Vector3 pos = vaisseau.transform.parent.InverseTransformPoint(vaisseau.transform.position);
        if (Input.GetKey(KeyCode.RightArrow) && pos.z - 1 > maxWidth)
        {
            dir += -transform.forward;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && pos.z + 1 < minWidth)
        {
            dir += transform.forward;
        }

        if (Input.GetKey(KeyCode.UpArrow) && pos.y + 1 < maxHeight)
        {
            dir += transform.up;
        }

        if (Input.GetKey(KeyCode.DownArrow) && pos.y - 1 > minHeight)
        {
            dir += -transform.up;
        }

        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            if (vaisseau.transform.rotation.w < 0)
            {
                vaisseau.transform.Rotate(Vector3.forward, -rotationSpeed * autoStableSpeed * Time.deltaTime);
            }

            if (vaisseau.transform.rotation.w > 0)
            {
                vaisseau.transform.Rotate(Vector3.forward, rotationSpeed * autoStableSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) && vaisseau.transform.rotation.w < tiltRight)
        {
            vaisseau.transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.LeftArrow) && vaisseau.transform.rotation.w > tiltlLeft)
        {
             vaisseau.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        vaisseau.transform.position += dir * speed * Time.deltaTime;
    }
}
