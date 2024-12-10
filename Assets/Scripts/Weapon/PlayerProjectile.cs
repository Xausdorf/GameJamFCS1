using UnityEngine;

public class PlayerProjectile : ProjectileBase
{
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
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
