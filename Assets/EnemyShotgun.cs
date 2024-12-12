using UnityEngine;

public class EnemyShotgun : EnemyGun
{
    [SerializeField]
    public int pelletCount = 3;
    [SerializeField]
    public int spread = 15;

    protected override void Fire()
    {
        if (target == null) return;

        if ((firePoint.position - target.transform.position).magnitude > screenSize - 1) return;

        Vector2 direction = target.transform.position - firePoint.position;
        transform.right = direction;

        for (int i = 0; i < pelletCount; i++)
        {
            Vector3 pelletDirection = Quaternion.Euler(0, 0, spread * (i - pelletCount / 2)) * (Vector3)direction;

            GameObject projectile = Instantiate(projectilePrefab,
                                firePoint.position + pelletDirection.normalized,
                                firePoint.rotation);

            ProjectileBase projectileScript = projectile.GetComponent<ProjectileBase>();
            projectileScript.direction = pelletDirection;
            projectileScript.damage = damage;
        }
    }
}
