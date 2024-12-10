using UnityEngine;

public class MeleeWeapon : WeaponBase
{
    public float attackDuration = 0.1f;
    public float attackAngle = 120f;
    public bool isAttacking = false;
    private float progress = 0f;
    private SpriteRenderer sr;
    private PolygonCollider2D hitbox;
    private Quaternion currentRotation;

    void Start()
    {
        currentRotation = transform.rotation;
        isAttacking = false;
        progress = 0f;
        sr = GetComponent<SpriteRenderer>();
        hitbox = GetComponent<PolygonCollider2D>();
        sr.enabled = false;
        hitbox.enabled = false;
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + attackDuration;
        }

        if (isAttacking)
        {
            PerformAttack();
        } else
        {
            FollowCursor();
        }
    }

    protected override void Fire()
    {
        if (isAttacking) return;

        isAttacking = true;
        progress = 0f;
        sr.enabled = true;
        hitbox.enabled = true;
        hitbox.transform.rotation = currentRotation;

        Invoke(nameof(StopAttack), attackDuration);
    }

    private void FollowCursor()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        currentRotation = Quaternion.Euler(0, 0, angle);
    }

    private void PerformAttack()
    {
        hitbox.transform.rotation = currentRotation;
        progress += Time.deltaTime;
        if (progress >= attackDuration)
        {
            StopAttack();
        }
    }

    private void StopAttack()
    {
        isAttacking = false;
        sr.enabled = false;
        hitbox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAttacking && collision.CompareTag("Enemy"))
        {
            Health enemyHealth = collision.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }
}
