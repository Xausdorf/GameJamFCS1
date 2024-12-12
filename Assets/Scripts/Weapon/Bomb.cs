using UnityEngine;

public class Bomb : Grenade
{
    void Start()
    {
        explosionRadius = 100f;
        explosionDelay = 2f;
        damage = 1000;
        Invoke(nameof(Explode), explosionDelay);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }
}
