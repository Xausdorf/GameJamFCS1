using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LifeCounter : MonoBehaviour
{
    public GameObject lifeIconPrefab;  // Префаб кружка жизни
    public Transform livesPanel;       // Панель, на которой будут размещаться кружки
    public int maxLives = 3;           // Количество жизней

    private List<GameObject> lifeIcons = new List<GameObject>();
    private int currentLives;

    void Start()
    {
        currentLives = maxLives;
        InitializeLives();
    }

    // Инициализация жизней (создание иконок)
    private void InitializeLives()
    {
        // Удаляем старые иконки
        foreach (Transform child in livesPanel)
        {
            Destroy(child.gameObject);
        }

        lifeIcons.Clear();

        // Создаем нужное количество иконок
        for (int i = 0; i < maxLives; i++)
        {
            GameObject lifeIcon = Instantiate(lifeIconPrefab, livesPanel);
            lifeIcons.Add(lifeIcon);
        }
    }

    // Потеря жизни
    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            UpdateLives();
        }
    }

    // Добавление жизни (например, за аптечку)
    public void GainLife()
    {
        if (currentLives < maxLives)
        {
            currentLives++;
            UpdateLives();
        }
    }

    // Обновление отображения жизней
    private void UpdateLives()
    {
        for (int i = 0; i < lifeIcons.Count; i++)
        {
            if (i < currentLives)
            {
                lifeIcons[i].SetActive(true); // Показываем жизнь
            }
            else
            {
                lifeIcons[i].SetActive(false); // Прячем жизнь
            }
        }
    }
}