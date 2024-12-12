using Pathfinding;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public float nextWaypointDistance = 0.5f;
    public Transform enemy;
    Seeker seeker;
    Path path;
    Rigidbody2D rb;
    int currentpos = 0;
    bool reachedPathEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);
        seeker.StartPath(rb.position, target.position);
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }
        if (currentpos >= path.vectorPath.Count)
        {
            reachedPathEnd = true;
            return;
        }
        else
        {
            reachedPathEnd = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentpos]-rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentpos]);

        if  (distance < nextWaypointDistance)
        {
            currentpos++;
        }
        if (rb.velocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f,1f, 1f);
        }
        else if (rb.velocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
