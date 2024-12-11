using UnityEngine;

public class PlayerHealth : Health
{
    public PlayerLifeCountController lifeCountController;
    private PlayerController playerController;

    protected override void Start()
    {
        maxHealth = 100;
        playerController = GetComponent<PlayerController>();
        if (lifeCountController == null)
        {
            lifeCountController = GameObject.Find("PlayerHealthManager").GetComponent<PlayerLifeCountController>();
        }
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
        lifeCountController.Die();
    }
}
