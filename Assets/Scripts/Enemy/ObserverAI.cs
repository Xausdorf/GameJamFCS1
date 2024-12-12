using UnityEngine;

public class ObserverAI : MonoBehaviour
{
    public Transform target;
    public float speed = 8f;
    public Vector2 direction = new Vector2(1, 1);

    void Start()
    {
        if (target == null) target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (target == null) return;

        Vector3 move = direction.normalized * speed * Time.deltaTime;
        Vector3 toTarget = transform.position - target.position;
        if (toTarget.y > 5)
        {
            move.y *= -1;
        } 
        if (toTarget.x < 0)
        {
            move.x *= -1;
        }

        transform.position += move;
    }
}
