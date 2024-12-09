using UnityEngine;

public class EnemyHealth : Health
{
    protected override void Start()
    {
        maxHealth = 20;
        base.Start();
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
