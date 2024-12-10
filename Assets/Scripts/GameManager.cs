using UnityEngine;
using UnityEngine.UI;  // Для UI

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton для доступа из других классов
    public int killCount = 0;  // Счётчик убитых врагов
    public Text killCountText;  // UI элемент для отображения счётчика

    void Awake()
    {
        // Проверка на Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Обновляем текст на экране
        if (killCountText != null)
        {
            killCountText.text = "Kills: " + killCount;
        }
    }

    // Метод для увеличения счётчика убитых врагов
    public void IncreaseKillCount()
    {
        killCount++;
    }
}

