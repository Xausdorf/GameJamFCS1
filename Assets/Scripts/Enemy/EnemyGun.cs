using UnityEngine;

public class EnemyGun : WeaponBase
{
    public float screenSize = 14.22f;
    public GameObject target;

    protected override void Start()
    {
        if (target == null)
        {
            target = GameObject.Find("Player");
        }
        base.Start();
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

        if ((firePoint.position - target.transform.position).magnitude > screenSize - 1) return;

        if (audioSource != null) audioSource.Play();

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
