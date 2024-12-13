using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PresentTaker : MonoBehaviour
{
    public QuestManager questManager;
    public ProgressBar progressBar;


    public bool isActive;
    private float contactTime = 0f; // Текущее время контакта
    private bool isPlayerInContact = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Проверяем, является ли объект игроком
        {
            isPlayerInContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Если игрок покидает объект
        {
            isPlayerInContact = false;
            contactTime = 0f; // Сбрасываем таймер
        }
    }

    private void Update()
    {
        int curQuest = questManager.CurLevel;
        int cur = questManager.Levels[curQuest].curTask;
        if (questManager.Levels[curQuest].objectives[cur].Type == 1) {
            isActive = true;
        } else {
            isActive = false;
            Inventory.instance.items["Present"] = 0;
        }
        if (isPlayerInContact && isActive)
        {
            contactTime += Time.deltaTime; // Увеличиваем таймер

            if (contactTime >= 1f)
            {
                if (Inventory.instance.items["Present"] > 0) {
                    Inventory.instance.RemoveItem("Present");
                    Debug.Log(progressBar.progressBar.value);
                    progressBar.UpdateGiftTask();
                    contactTime = 0f; // Сбрасываем таймер после применения эффекта
                }
            }
        }
    }

    void Start() {
        questManager = FindObjectOfType<QuestManager>();
        progressBar = FindObjectOfType<ProgressBar>();
    }
}
