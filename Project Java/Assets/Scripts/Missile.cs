using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 10f;
    public ParticleSystem trace;
    public float damage = 1f;
    public float lifeTime = 10f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
        if (trace != null)
            trace.Play();
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destroyable")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy" && gameObject.tag != "Enemy Projectile")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
