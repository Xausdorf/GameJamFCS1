using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7f;  // Скорость перемещения
    public float jumpForce = 10f;  // Сила прыжка
    public float dashSpeed = 20f;  // Скорость рывка
    public float dashDuration = 0.3f;  // Длительность рывка
    public float dashCooldown = 1f;  // Время до следующего рывка

    public bool isInvincible = false;
    private bool isGrounded;
    private bool isDashing;
    private bool canDoubleJump;
    private bool isFacingRight = true;
    private float nextDashTime = 0;

    private Rigidbody2D rb;
    private Animator animator;  // Для анимаций, если нужно

    private Vector2 moveInput;

    void Start()
    {
        nextDashTime = 0;
        rb = GetComponent<Rigidbody2D>();
        // animator = GetComponent<Animator>();  // если у вас есть аниматор
    }

    void Update()
    {
        // Получение ввода
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

        // Смотрим положение курсора на экране
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;

        // Перемещение влево/вправ
        if (!isDashing)
        {
            rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        }

        // Перемещение персонажа влево/вправ по горизонтали в воздухе
        if (direction.x < 0 && isFacingRight)
        {
            Flip(); // Поворот спрайта влево
        }
        else if (direction.x > 0 && !isFacingRight)
        {
            Flip(); // Поворот спрайта вправо
        }

        // Прыжки
        if (isGrounded)
        {
            canDoubleJump = true; // Разрешаем второй прыжок, если на земле
        }

        if (Input.GetButtonDown("Jump") && (isGrounded || canDoubleJump))
        {
            Jump();
        }

        // Дешинг
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && Time.time >= nextDashTime)
        {
            StartCoroutine(Dash());
        }

        // Спуск с платформы
        if (isGrounded && Input.GetKeyDown(KeyCode.S))
        {
            FallThroughPlatform();
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
        else if (canDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canDoubleJump = false;
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        isInvincible = true;

        float dashDirection = (moveInput.x != 0) ? moveInput.x : (isFacingRight ? 1f : -1f);
        rb.velocity = new Vector2(dashDirection * dashSpeed, rb.velocity.y);

        nextDashTime = Time.time + dashCooldown;

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
        isInvincible = false;
    }

    private void FallThroughPlatform()
    {
        rb.velocity = new Vector2(rb.velocity.x, -5f);  // Ускорение вниз
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;  // Поворот спрайта
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;  // При касании с землей
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;  // При выходе с земли
    }
}
