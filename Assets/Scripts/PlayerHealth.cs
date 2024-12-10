using UnityEngine;

public class PlayerHealth : Health
{
    public int maxLifeCount = 3;
    public int curLifeCount = 0;
    public Vector3 spawnPoint = new Vector3(3, 3, 0);

    protected override void Start()
    {
        maxHealth = 100;
        maxLifeCount = 3;
        curLifeCount = maxLifeCount;
        base.Start();
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
