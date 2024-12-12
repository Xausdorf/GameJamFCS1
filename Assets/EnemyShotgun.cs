using System.Collections;
using System.Collections.Generic;
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

        Vector2 direction = target.transform.position - firePoint.position;
        transform.right = direction;

        GameObject projectile = Instantiate(projectilePrefab,
                                            firePoint.position + (Vector3)direction.normalized,
                                            firePoint.rotation);

        ProjectileBase projectileScript = projectile.GetComponent<ProjectileBase>();
        projectileScript.direction = direction;
        projectileScript.damage = damage;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
