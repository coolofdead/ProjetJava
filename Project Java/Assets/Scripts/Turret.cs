using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, IDamageable
{
    public Missile missilePrefab;
    public Transform[] canonAnchors;

    public float gustDelay, maxGustDelay, shotDelay;
    public int shotPerGust;

    AudioSource shoot;
    public AudioClip[] shoots;

    private void Start()
    {
        shoot = GetComponent<AudioSource>();
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

            shoot.clip = shoots[Random.Range(0, shoots.Length)];
            shoot.Play();

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
