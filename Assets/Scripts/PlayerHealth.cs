using UnityEngine;

public class PlayerHealth : Health
{
    protected override void Start()
    {
        maxHealth = 100;
        base.Start();
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
