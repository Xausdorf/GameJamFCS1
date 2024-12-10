using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public int damage = 10;
    protected float nextFireTime;

    protected virtual void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    protected virtual void Fire()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - firePoint.position;
        transform.right = direction;

        GameObject projectile = Instantiate(projectilePrefab, 
                                            firePoint.position + (Vector3)direction.normalized, 
                                            firePoint.rotation);

        ProjectileBase projectileScript = projectile.GetComponent<ProjectileBase>();
        projectileScript.direction = direction;
        projectileScript.damage = damage;
    }

    public virtual void Activate(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
