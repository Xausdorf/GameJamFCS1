using UnityEngine;
using TMPro;

public class TaskUpdater : MonoBehaviour
{
    public QuestManager questManager;    // Ссылка на QuestManager
    public TextMeshProUGUI subTaskText;
    // Start is called before the first frame update
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>(); // Найти QuestManager в сцене
        // subTaskText = GameObject.Find("SubTaskText");
        // int curQuest = questManager.CurLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (questManager != null) {
            int curQuest = questManager.CurLevel;
            int cur = questManager.Levels[curQuest].curTask;
            subTaskText.text = questManager.Levels[curQuest].objectives[0].QuestDescription;
            // gameObject.SetActive(true);
            if (questManager.Levels[curQuest].objectives[cur].isCompleted) {
                UpdateTaskObjectiveUI();
                // gameObject.SetActive(true);
            }
            // subTaskText.text = "ГОЙДА";
            if (subTaskText == null) {
                Debug.LogError("Компонент Text не найден на объекте SubTaskText!");
            }
            
        }
    }

    public void UpdateTaskObjectiveUI()
    {
        int curQuest = questManager.CurLevel;
        int cur = questManager.Levels[curQuest].curTask;
        if (cur < questManager.Levels[curQuest].amount)
        {
            TaskObjective currentSubTask = questManager.Levels[curQuest].objectives[cur];
            questManager.Levels[curQuest].curTask++;
            subTaskText.text = currentSubTask.QuestDescription; // Обновляем текст подзадачи
        }
    }
}
