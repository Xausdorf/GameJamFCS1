using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;
    public int damage = 10;
    public Vector2 direction = Vector2.up;

    protected virtual void Start()
    {
        Destroy(gameObject, lifetime);
    }

    protected virtual void Update()
    {
        Vector2 direction = GetDirection();
        Vector3 move = direction.normalized * speed * Time.deltaTime;
        transform.position += move;

        float angle = (Mathf.Atan2(direction.y, direction.x) - Mathf.PI / 2) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    protected virtual Vector2 GetDirection()
    {
        return direction;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
