using UnityEngine;

public class MeleeWeapon : WeaponBase
{
    public float attackDuration = 0.4f;
    public float attackAngle = 120f;
    public bool isAttacking = false;
    private float progress = 0f;
    private SpriteRenderer sr;

    void Start()
    {
        fireRate = 0.4f;
        attackDuration = 0.4f;
        isAttacking = false;
        progress = 0f;
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    protected override void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextFireTime)
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

        isAttacking = true;
        progress = 0f;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - firePoint.position;

        transform.RotateAround(firePoint.position, new Vector3(0, 0, -1), Mathf.Atan2(direction.y, direction.x));
        transform.RotateAround(firePoint.position, new Vector3(0, 0, -1), -attackAngle / 2);

        sr.enabled = true;

        Invoke(nameof(StopAttack), attackDuration);
    }

    private void PerformAttack()
    {
        sr.enabled = true;
        progress += Time.deltaTime;
        transform.RotateAround(firePoint.position, new Vector3(0, 0, -1), attackAngle / attackDuration * Time.deltaTime);
        if (progress >= attackDuration)
        {
            StopAttack();
        }
    }

    private void StopAttack()
    {
        isAttacking = false;
        sr.enabled = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = firePoint.position + new Vector3(0, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Health enemyHealth = collision.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }
}
