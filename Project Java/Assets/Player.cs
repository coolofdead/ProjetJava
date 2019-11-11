using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform canonDroit;
    public Transform canonGauche;

    public GameObject missilePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(Instantiate(missilePrefab, canonDroit.position, canonDroit.rotation), 10f);
            Destroy(Instantiate(missilePrefab, canonGauche.position, canonGauche.rotation), 10f);
        }
    }
}
