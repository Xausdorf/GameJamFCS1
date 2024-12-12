using UnityEngine;

public class EnemyHealth : Health
{
    public PlayerGrenadeThrower grenadeThrower;
    public EnemySpawner spawner;

    protected override void Start()
    {
        grenadeThrower = GameObject.Find("Player").GetComponent<PlayerGrenadeThrower>();
        maxHealth = 20;
        base.Start();
    }

    public override void TakeDamage(int damage)
    {
        curHealth -= damage;

        if (grenadeThrower != null)
        {
            grenadeThrower.AddEnergy(damage);
            if (curHealth < 0)
            {
                grenadeThrower.AddEnergy(curHealth);
            }
        }

        if (curHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        if (spawner != null)
        {
            spawner.enemyCount--;
        }
        Destroy(gameObject);
    }
}
