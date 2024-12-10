using UnityEngine;

public class FollowsCursor : MonoBehaviour
{
    public float startAngle = 90;
    private bool isFacingRight = true;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;

        if (direction.x < 0 && isFacingRight)
        {
            Flip(); // Поворот спрайта влево
        }
        else if (direction.x > 0 && !isFacingRight)
        {
            Flip(); // Поворот спрайта вправо
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - startAngle;
        if (!isFacingRight)
        {
            angle -= 180;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
    }
}
