using UnityEngine;

public class EnemyProjectile : ProjectileBase
{
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Health targetHealth = collider.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
