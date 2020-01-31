using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, IDamageable
{
    public Missile missilePrefab;
    public Transform[] canonAnchors;

    public float gustDelay;
    public float maxGustDelay;
    public int shotPerGust;
    public float shotDelay;

    private void Start()
    {
        Invoke("StartShooting", Random.Range(gustDelay, maxGustDelay));
    }

    void StartShooting()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        for(int i = 0; i < shotPerGust; i++)
        {
            foreach (Transform canonAnchor in canonAnchors)
                Instantiate(missilePrefab.gameObject, canonAnchor.position, canonAnchor.rotation);

            yield return new WaitForSeconds(shotDelay);
        }

        yield return new WaitForSeconds(Random.Range(gustDelay, maxGustDelay));

        StartCoroutine(Shooting());
    }

    public void TakeDamage(int amount, bool instantKill = false)
    {
        gameObject.SetActive(false);
    }
}
