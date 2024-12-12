using Pathfinding;
using UnityEngine;

public class BomberAI : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionRadius = 5f;
    public int explosionDamage = 30;
    public float accelerationRadius = 5f;
    public float acceleration = 5f;
    private FollowTarget aiPath;
    private float normalSpeed;
    private Transform target;
    private bool isAccelerated;

    void Start()
    {
        aiPath = GetComponent<FollowTarget>();
        normalSpeed = aiPath.speed;
        isAccelerated = false;
        target = GetComponent<FollowTarget>().target.transform;
        if (target == null) target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        float toTarget = (transform.position - target.position).magnitude;
        if (toTarget <= accelerationRadius && !isAccelerated)
        {
            aiPath.speed += acceleration;
            isAccelerated = true;
        } else if (toTarget > accelerationRadius && isAccelerated)
        {
            aiPath.speed = normalSpeed;
            isAccelerated = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Explode();
        }
    }

    protected void Explode()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 90)));
        Destroy(explosion, 0.2f);

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D hitObject in hitObjects)
        {
            if (hitObject.CompareTag("Player"))
            {
                Health hitHealth = hitObject.GetComponent<Health>();
                if (hitHealth != null)
                {
                    hitHealth.TakeDamage(explosionDamage);
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
