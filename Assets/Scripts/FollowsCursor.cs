using UnityEngine;

public class FollowsCursor : MonoBehaviour
{
    public float startAngle = 90;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - startAngle;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
