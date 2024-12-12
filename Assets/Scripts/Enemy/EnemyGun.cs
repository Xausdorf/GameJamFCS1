using UnityEngine;

public class EnemyGun : WeaponBase
{
    public GameObject target;

    protected override void Update()
    {
        Vector2 oldDirection = target.transform.position;
        if (Time.time >= nextFireTime)
        {
            Fire();
            transform.right = oldDirection;
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
