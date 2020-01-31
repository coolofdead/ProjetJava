using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    public float lifeTime = 10f;

    [SerializeField]
    private bool isAlliedMissile;
    public bool isFromPlayer = false;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable unit = other.gameObject.GetComponent<IDamageable>();

        if (unit != null)
        {
            if (!isAlliedMissile)
            {
                if (unit is Player || unit is Allied)
                {
                    unit.TakeDamage(damage);
                }
            }

            if (isAlliedMissile)
            {
                if (unit is Enemy)
                {
                    GoalIndicatorManager.SetEnemyReference(other.transform);
                    unit.TakeDamage(damage);
                }
            }

            Destroy(gameObject);
        }
    }
}
