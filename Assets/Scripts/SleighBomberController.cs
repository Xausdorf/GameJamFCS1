using UnityEngine;

public class SleighBomberController : MonoBehaviour
{
    public bool isActive = false;
    public float yCoord = 15f;
    public float xBorder = 70;
    public float speed = 20f;
    public float bombDistance = 5f;
    public GameObject bombPrefab;
    private SpriteRenderer sr;
    private float lastBombCoord = -70;

    void Start()
    {
        isActive = false;
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        lastBombCoord = -xBorder;
        // Invoke(nameof(Activate), 5f);
    }

    void Update()
    {
        if (!isActive) return;

        Vector3 move = Vector3.right * speed * Time.deltaTime;
        transform.position += move;

        if (transform.position.x >= lastBombCoord + bombDistance)
        {
            Instantiate(bombPrefab, transform.position + 2 * Vector3.down, Quaternion.Euler(0, 0, -45));
            lastBombCoord = transform.position.x;
        }

        if (transform.position.x > xBorder)
        {
            isActive = false;
            sr.enabled = false;
        }
    }

    public void Activate()
    {
        if (isActive) return;

        isActive = true;
        sr.enabled = true;
        transform.position = new Vector2(-xBorder, yCoord);
    }
}
