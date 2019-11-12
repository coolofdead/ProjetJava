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

    public float tiltRight;
    public float tiltlLeft;

    public float life = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(missilePrefab, canonDroit.position, canonDroit.rotation);
            Instantiate(missilePrefab, canonGauche.position, canonGauche.rotation);
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
            if (vaisseau.transform.rotation.x > 0)
            {
                vaisseau.transform.Rotate(Vector3.right, -rotationSpeed * 2 * Time.deltaTime);
            }

            if (vaisseau.transform.rotation.x < 0)
            {
                vaisseau.transform.Rotate(Vector3.right, rotationSpeed * 2 * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) && vaisseau.transform.rotation.x > tiltRight)
        {
            if (vaisseau.transform.rotation.x < 0)
            {
                vaisseau.transform.Rotate(Vector3.right, -rotationSpeed * Time.deltaTime);
            }
            else
            {
                vaisseau.transform.Rotate(Vector3.right, -rotationSpeed * 2 * Time.deltaTime);
            }
        }


        if (Input.GetKey(KeyCode.LeftArrow) && vaisseau.transform.rotation.x < tiltlLeft)
        {
            if (vaisseau.transform.rotation.x > 0)
            {
                vaisseau.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
            }
            else
            {
                vaisseau.transform.Rotate(Vector3.right, rotationSpeed * 2 * Time.deltaTime);
            }
        }

        vaisseau.transform.position += dir * speed * Time.deltaTime;
    }
}
