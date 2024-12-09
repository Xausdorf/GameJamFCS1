using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public int maxHealth = 20;
    private int curHealth;

    protected virtual void Start()
    {
        curHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        curHealth -= damage;

        if (curHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int heal)
    {
        curHealth = System.Math.Max(curHealth + heal, maxHealth);
    }

    public abstract void Die();
}
