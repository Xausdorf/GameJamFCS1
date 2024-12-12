using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject target;
    public float speed = 5f;

    private void Start()
    {
        if (target == null) target = GameObject.Find("Player");
    }

    void Update()
    {
        if (target == null) return;

        Vector2 direction = target.transform.position - transform.position;

        Vector3 move = direction.normalized * speed * Time.deltaTime;
        transform.position += move;
    }
}
