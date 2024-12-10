using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // Персонаж, за которым следует камера

    [Header("Camera Settings")]
    public Vector2 offset; // Смещение камеры относительно персонажа
    public float smoothSpeed = 0.0125f; // Скорость сглаживания движения

    private Vector3 desiredPosition; // Желаемая позиция камеры
    private Vector3 smoothedPosition; // Плавная позиция камеры

    private void LateUpdate()
    {
        if (target != null)
        {
            // Рассчитываем желаемую позицию камеры
            desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);

            // Плавное движение камеры с использованием линейной интерполяции
            smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Обновляем позицию камеры
            transform.position = smoothedPosition;
        }
    }
}