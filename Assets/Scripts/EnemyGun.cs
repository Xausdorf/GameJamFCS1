using UnityEngine;

public class EnemyGun : WeaponBase
{
    public GameObject target;

    private void Start()
    {
        if (target == null)
        {
            target = GameObject.Find("Player");
        }
    }

    protected override void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    protected override void Fire()
    {
        if (target == null) return;

        Vector2 direction = target.transform.position - firePoint.position;
        transform.right = direction;

        GameObject projectile = Instantiate(projectilePrefab,
                                            firePoint.position + (Vector3)direction.normalized,
                                            firePoint.rotation);

        ProjectileBase projectileScript = projectile.GetComponent<ProjectileBase>();
        projectileScript.direction = direction;
        projectileScript.damage = damage;
    }
}
