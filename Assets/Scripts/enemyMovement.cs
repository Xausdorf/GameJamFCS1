using Pathfinding;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public float nextWaypointDistance = 0.5f;
    Seeker seeker;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
