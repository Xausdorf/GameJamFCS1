using UnityEngine;

public class OneWayPlatformController : MonoBehaviour
{
    private Collider2D platformCollider;
    private Rigidbody2D rb;

    [SerializeField]
    private float disableDuration = 0.2f; // Время, на которое отключается коллайдер

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, если это платформа с Platform Effector
        if (collision.GetComponent<PlatformEffector2D>())
        {
            platformCollider = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == platformCollider)
        {
            platformCollider = null;
        }
    }

    private void Update()
    {
        if (platformCollider != null && Input.GetKey(KeyCode.DownArrow))
        {
            StartCoroutine(DisablePlatformCollider());
        }
    }

    private System.Collections.IEnumerator DisablePlatformCollider()
    {
        platformCollider.enabled = false;
        yield return new WaitForSeconds(disableDuration);
        platformCollider.enabled = true;
    }
}