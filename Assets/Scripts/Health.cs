using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public int maxHealth = 20;
    public int curHealth;

    protected virtual void Start()
    {
        curHealth = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        curHealth -= damage;

        if (curHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Heal(int heal)
    {
        curHealth = System.Math.Min(curHealth + heal, maxHealth);
    }

    public abstract void Die();
}
