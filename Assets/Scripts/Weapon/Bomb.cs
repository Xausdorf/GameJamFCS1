using UnityEngine;

public class Bomb : Grenade
{
    void Start()
    {
        Invoke(nameof(Explode), explosionDelay);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }
}
