using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskUpdater : MonoBehaviour
{
    public QuestManager questManager;    // Ссылка на QuestManager
    public Text subTaskText;
    // Start is called before the first frame update
    void Start()
    {
        if (questManager == null)
            questManager = FindObjectOfType<QuestManager>(); // Найти QuestManager в сцене
        UpdateTaskObjectiveUI();
    }

    // Update is called once per frame
    void Update()
    {
        int curQuest = questManager.CurLevel;
        int cur = questManager.Levels[curQuest].curTask;
        if (questManager.Levels[curQuest].objectives[cur].isCompleted) {
            UpdateTaskObjectiveUI();
        }
    }

    public void UpdateTaskObjectiveUI()
    {
        int curQuest = questManager.CurLevel;
        int cur = questManager.Levels[curQuest].curTask;
        if (cur < questManager.Levels[curQuest].amount)
        {
            TaskObjective currentSubTask = questManager.Levels[curQuest].objectives[cur];
            subTaskText.text = currentSubTask.QuestDescription; // Обновляем текст подзадачи
        }
    }
}
