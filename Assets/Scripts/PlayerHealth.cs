using UnityEngine;

public class PlayerHealth : Health
{
    public int maxLifeCount = 3;
    public int curLifeCount = 0;
    public Vector3 spawnPoint = new Vector3(3, 3, 0);
    PlayerController playerController;

    protected override void Start()
    {
        maxHealth = 100;
        maxLifeCount = 3;
        curLifeCount = maxLifeCount;
        playerController = GetComponent<PlayerController>();
        base.Start();
    }

    public override void TakeDamage(int damage)
    {
        if (playerController.isInvincible) return;

        curHealth -= damage;

        if (curHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        curLifeCount--;
        if (curLifeCount <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            curHealth = maxHealth;
            gameObject.transform.position = spawnPoint;
        }
    }
}
