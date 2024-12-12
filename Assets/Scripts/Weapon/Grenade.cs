using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float throwForce = 10f;
    public float explosionRadius = 2f;
    public float explosionDelay = 3f;
    public int damage = 50;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke(nameof(Explode), explosionDelay);
    }

    public void Throw(Vector2 direction)
    {
        Start();
        rb.AddForce(direction.normalized * throwForce, ForceMode2D.Impulse);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Explode();
        }
    }

    protected void Explode()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D hitObject in hitObjects)
        {
            if (hitObject.CompareTag("Enemy"))
            {
                Health hitHealth = hitObject.GetComponent<Health>();
                if (hitHealth != null)
                {
                    hitHealth.TakeDamage(damage);
                }
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
