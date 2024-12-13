using UnityEngine;

public class MeleeWeapon : WeaponBase
{
    public float attackDuration = 0.1f;
    public float attackAngle = 120f;
    public bool isAttacking = false;
    public SpriteRenderer swordSr;
    private float progress = 0f;
    private SpriteRenderer sr;
    private PolygonCollider2D hitbox;

    protected override void Start()
    {
        isAttacking = false;
        progress = 0f;
        swordSr.enabled = false;
        sr = GetComponent<SpriteRenderer>();
        hitbox = GetComponent<PolygonCollider2D>();
        sr.enabled = false;
        hitbox.enabled = false;
        base.Start();
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
        }
    }

    protected override void Fire()
    {
        if (isAttacking) return;

        if (audioSource != null) audioSource.Play();

        isAttacking = true;
        progress = 0f;
        sr.enabled = true;
        hitbox.enabled = true;

        Invoke(nameof(StopAttack), attackDuration);
    }

    private void PerformAttack()
    {
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

    public override void Activate(bool isActive)
    {
        if (isActive)
        {
            swordSr.enabled = true;
        } else
        {
            swordSr.enabled = false;
        }
        base.Activate(isActive);
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
