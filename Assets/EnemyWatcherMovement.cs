using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWatcherMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Transform player = GameObject.Find("Player").transform;
    float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction;
        if (player.transform.position.x < rb.transform.position.x)
        {
            direction = new Vector2(rb.transform.position.x - 3, rb.transform.position.y).normalized;
        }
        else
        {
            direction = new Vector2(rb.transform.position.x + 3, rb.transform.position.y).normalized;
        }
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        if (rb.velocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}