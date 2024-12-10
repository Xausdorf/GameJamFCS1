using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private PlatformEffector2D platformEffector;

    [SerializeField]
    private float fallThroughDelay = 0.2f; // Время задержки для падения сквозь платформу

    private void Start()
    {
        platformEffector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        // Проверка на нажатие вниз для спрыгивания
        if (Input.GetKey(KeyCode.S))
        {
            platformEffector.rotationalOffset = 180f; // Позволяем падение сквозь платформу

            // Возвращаем нормальное поведение через задержку
            Invoke(nameof(ResetPlatform), fallThroughDelay);
        }
    }

    private void ResetPlatform()
    {
        platformEffector.rotationalOffset = 0f; // Восстанавливаем возможность стоять на платформе
    }
}