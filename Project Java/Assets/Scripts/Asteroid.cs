using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour, IDamageable
{
    private Vector3 rotateDir;
    private const float minRotateSpeed = 5f;
    private const float maxRotateSpeed = 40f;
    private int life = 1;

    private void Start()
    {
        rotateDir = Random.insideUnitSphere * Random.Range(minRotateSpeed, maxRotateSpeed);
    }

    private void Update()
    {
        transform.Rotate(rotateDir * Time.deltaTime);
    }

    public void TakeDamage(int amount, bool instantKill = false)
    {
        Destroy(gameObject);
    }
}
